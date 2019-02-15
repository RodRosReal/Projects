using Domain.Core;
using Domain.ValueObjects;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Repositories.Relational
{
    public class Repository<TEntity>
        where TEntity : class
    {
        private DbContext dbContext;
        private DbSet<TEntity> dbSet;

        public Repository()
        {
            var context = DataContextFactory.GetDataContext();
            this.dbContext = context ?? throw new ArgumentNullException(nameof(context));
            this.dbSet = this.dbContext.Set<TEntity>();
        }

        public TEntity Get(params object[] keys)
        {
            if (keys == null)
                throw new ArgumentNullException(nameof(keys));

            return this.dbSet.Find(keys);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> spec)
        {
            if (spec == null)
                throw new ArgumentNullException(nameof(spec));

            return this.QueryAsTracking().FirstOrDefault(spec);
        }

        public TEntity GetFirst()
        {
            return this.Query().FirstOrDefault();
        }

        public TEntity GetLast()
        {
            return this.Query().LastOrDefault();
        }

        public List<TEntity> Query(Expression<Func<TEntity, bool>> spec)
        {
            if (spec == null)
                return this.Query().ToList();

            return this.Query()
                .Where(spec)
                .ToList();
        }

        public List<TEntity> Query(Expression<Func<TEntity, bool>> spec, string orderBy, SortDirection direction)
        {
            if (spec == null)
                throw new ArgumentNullException(nameof(spec));

            var query = this.Query();
            if (!string.IsNullOrEmpty(orderBy))
                query = query.OrderBy(orderBy, direction);

            return query
                .Where(spec)
                .ToList();
        }

        public List<TEntity> QueryAll(int limitCount = RepositoryConstants.DefaultQueryLimitCount)
        {
            return this.Query()
                .Take(limitCount)
                .ToList();
        }

        public PagedResult<TEntity> QueryPaged(PagedOptions pagedOptions)
        {
            if (pagedOptions == null)
                throw new ArgumentNullException(nameof(pagedOptions));

            var query = this.Query();

            if (!string.IsNullOrEmpty(pagedOptions.OrderBy))
                query = query.OrderBy(pagedOptions.OrderBy, pagedOptions.Direction);

            return query.ToPaged(pagedOptions.PageNumber, pagedOptions.PageSize, pagedOptions.IncludeTotalCount);
        }

        public PagedResult<TEntity> QueryPaged(PagedOptions pagedOptions, Expression<Func<TEntity, bool>> spec)
        {
            if (pagedOptions == null)
                throw new ArgumentNullException(nameof(pagedOptions));

            if (spec == null)
                throw new ArgumentNullException(nameof(spec));

            var query = this.Query().Where(spec);

            if (!string.IsNullOrEmpty(pagedOptions.OrderBy))
                query = query.OrderBy(pagedOptions.OrderBy, pagedOptions.Direction);

            return query.ToPaged(pagedOptions.PageNumber, pagedOptions.PageSize, pagedOptions.IncludeTotalCount);
        }

        public bool Exists()
        {
            return this.Query().Any();
        }

        public bool Exists(Expression<Func<TEntity, bool>> spec)
        {
            if (spec == null)
                throw new ArgumentNullException(nameof(spec));

            return this.Query().Any(spec);
        }

        public long Count()
        {
            return this.Query().LongCount();
        }

        public long Count(Expression<Func<TEntity, bool>> spec)
        {
            if (spec == null)
                throw new ArgumentNullException(nameof(spec));

            return this.Query().LongCount(spec);
        }

        public void Insert(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

             this.dbContext.Entry(entity).State = EntityState.Added;
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

           this.dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            this.dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public void ExecuteSqlCommand(string cmd)
        {
            this.dbContext.Database.ExecuteSqlCommand(cmd);
            DataContextFactory.Clear();
            var context = DataContextFactory.GetDataContext();
            this.dbContext = context ?? throw new ArgumentNullException(nameof(context));
            this.dbSet = this.dbContext.Set<TEntity>();
        }        

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected IQueryable<TEntity> Query()
        {
            return this.dbSet.AsNoTracking();
        }

        protected IQueryable<TEntity> QueryAsTracking()
        {
            return this.dbSet;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && this.dbContext != null)
                this.dbContext.Dispose();
        }
    }
}
