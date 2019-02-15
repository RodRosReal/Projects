using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Core
{
    public interface IRepository<TEntity>
    {
        TEntity Get(params object[] keys);

        TEntity Get(Expression<Func<TEntity, bool>> spec);

        TEntity GetFirst();

        TEntity GetLast();

        List<TEntity> Query(Expression<Func<TEntity, bool>> spec);

        List<TEntity> Query(Expression<Func<TEntity, bool>> spec, string orderBy, SortDirection direction);

        List<TEntity> QueryAll(int limitCount = RepositoryConstants.DefaultQueryLimitCount);

        PagedResult<TEntity> QueryPaged(PagedOptions pagedOptions);

        PagedResult<TEntity> QueryPaged(PagedOptions pagedOptions, Expression<Func<TEntity, bool>> spec);

        bool Exists();

        bool Exists(Expression<Func<TEntity, bool>> spec);

        long Count();

        long Count(Expression<Func<TEntity, bool>> spec);

        void Insert(TEntity entity);

        void Update(TEntity entity);      

        void Delete(TEntity entity);

        void ExecuteSqlCommand(string cmd);
    }
}
