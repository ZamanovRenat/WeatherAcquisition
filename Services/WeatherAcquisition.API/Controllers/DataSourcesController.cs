using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherAcquisition.DAL.Entities;
using WeatherAcquisition.Interfaces.Base.Repositories;

namespace WeatherAcquisition.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataSourcesController : ControllerBase
    {
        private readonly IRepository<DataSource> _repository;
        public DataSourcesController(IRepository<DataSource> Repository) => _repository = Repository;

        [HttpGet("count")]
        //Документирование статусных кодов WebAPI
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public async Task<IActionResult> GetItemsCount() => Ok(await _repository.GetCount());
        //Проверка наличия объекта по ID
        [HttpGet("exist/id/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(bool))]
        public async Task<IActionResult> ExistId(int id) => await _repository.ExistId(id) ? Ok(true) : NotFound(false);
        //Получение всех объектов
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll() => Ok(await _repository.GetAll());
        //Получение объектов с возможностью пропуска
        [HttpGet("Items[[{Skip:int}:{Count:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<DataSource>>> Get(int Skip, int Count) =>
            Ok(await _repository.Get(Skip, Count));
        //Получение страниц объектов
        [HttpGet("page/{PageIndex:int}/{PageSize:int}")]
        [HttpGet("page[[{PageIndex:int}/{PageSize:int}]]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IPage<DataSource>>> GetPage(int PageIndex, int PageSize)
        {
            var result = await _repository.GetPage(PageIndex, PageSize);
            return result.Items.Any() ? Ok(result) : NotFound(result);
        }
    }
}
