using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Core
{
    public interface IRepository<TEntity>: IRepository
        where TEntity : IEntity
    {
        Task<TEntity> Get(params object[] keys);

        Task<TEntity> Get(Expression<Func<TEntity, bool>> spec);

        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> spec);

        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> spec, string orderBy, SortDirection direction);

        Task<List<TEntity>> QueryAll(int limitCount = RepositoryConstants.DefaultQueryLimitCount);

        Task<PagedResult<TEntity>> QueryPaged(PagedOptions pagedOptions);

        Task<PagedResult<TEntity>> QueryPaged(PagedOptions pagedOptions, Expression<Func<TEntity, bool>> spec);

        Task<bool> Exists();

        Task<bool> Exists(Expression<Func<TEntity, bool>> spec);

        Task<long> Count();

        Task<long> Count(Expression<Func<TEntity, bool>> spec);

        Task Insert(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(TEntity entity);
    }
}
