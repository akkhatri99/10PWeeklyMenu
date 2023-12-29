using MongoDB.Bson;
using MongoDB.Driver.Linq;
using MongoDB.Driver;
using PortfolioServer.Models;
using System.Linq.Expressions;

namespace PortfolioServer.DAL
{
    public interface IMongoRepository<T, TKey> : IMongoQueryable<T>
        where T : IMongoEntity<TKey>
    {
        IMongoCollection<T> Collection { get; }

        T GetById(TKey id);

        Task<T> GetByIdAsync(TKey id, CancellationToken cancellationToken = default(CancellationToken));

        T Add(T entity);

        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default(CancellationToken));

        void Add(IEnumerable<T> entities);

        Task AddAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default(CancellationToken));

        T Update(T entity);

        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default(CancellationToken));

        void Delete(TKey id);

        Task DeleteAsync(TKey id, CancellationToken cancellationToken = default(CancellationToken));

        void Delete(Expression<Func<T, bool>> predicate);

        Task DeleteAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken));

        void DeleteAll();

        Task DeleteAllAsync(CancellationToken cancellationToken = default(CancellationToken));

        bool Exists(Expression<Func<T, bool>> predicate);

        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken));

    }

    public interface IMongoRepository<T> : IMongoQueryable<T>, IMongoRepository<T, ObjectId>
        where T : IMongoEntity<ObjectId>
    {
        //Task<IEnumerable<CompanyWidgetsDate>> GetAllCompanyWidgets<T>(ObjectId viewId);
    }

}
