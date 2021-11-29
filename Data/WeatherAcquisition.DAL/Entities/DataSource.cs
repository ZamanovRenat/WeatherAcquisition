using Microsoft.EntityFrameworkCore;
using WeatherAcquisition.DAL.Entities.Base;

namespace WeatherAcquisition.DAL.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class DataSource : NamedEntity
    {
        public string Description { get; set; }
    }
}
