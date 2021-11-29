using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WeatherAcquisition.Interfaces.Base.Entities;

namespace WeatherAcquisition.Interfaces.Base.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        Task<bool> ExistId(int Id, CancellationToken Cancel = default);

        Task<bool> Exist(T item, CancellationToken Cancel = default);

        Task<int> GetCount(CancellationToken Cancel = default);

        Task<IEnumerable<T>> GetAll(CancellationToken Cancel = default);

        Task<IEnumerable<T>> Get(int Skip, int Count, CancellationToken Cancel = default);

        Task<IPage<T>> GetPage(int PageIndex, int PageSize, CancellationToken Cancel = default);

        Task<T> GetById(int Id, CancellationToken Cancel = default);

        Task<T> Add(T item, CancellationToken Cancel = default);

        Task<T> Update(T item, CancellationToken Cancel = default);

        Task<T> Delete(T item, CancellationToken Cancel = default);

        Task<T> DeleteById(int Id, CancellationToken Cancel = default);
    }

    public interface IPage<out T>
    {
        IEnumerable<T> Items { get; }

        int TotalCount { get; }

        int PageIndex { get; }

        int PageSize { get; }

        int TotalPagesCount { get; }
    }
}