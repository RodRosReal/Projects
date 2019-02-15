using Domain.Core;
using Domain.ValueObjects;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Relational
{
    public class RelationalRepository<TEntity, TKey> : IRepository<TEntity>
       where TEntity : BaseEntity<TKey>
    {
        private DbContext dbContext;
        private DbSet<TEntity> dbSet;

        public RelationalRepository()
        {
            var context = DataContextFactory.GetDataContext();
            this.dbContext = context ?? throw new ArgumentNullException(nameof(context));
            this.dbSet = this.dbContext.Set<TEntity>();
        }

        public Task<TEntity> Get(params object[] keys)
        {
            if (keys == null)
                throw new ArgumentNullException(nameof(keys));

            return this.dbSet.FindAsync(keys);
        }

        public Task<TEntity> Get(Expression<Func<TEntity, bool>> spec)
        {
            if (spec == null)
                throw new ArgumentNullException(nameof(spec));

            return this.QueryAsTracking().FirstOrDefaultAsync(spec);
        }

        public Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> spec)
        {
            if (spec == null)
                return this.Query().ToListAsync();

            return this.Query()
                .Where(spec)
                .ToListAsync();
        }

        public Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> spec, string orderBy, SortDirection direction)
        {
            if (spec == null)
                throw new ArgumentNullException(nameof(spec));

            var query = this.Query();
            if (!string.IsNullOrEmpty(orderBy))
                query = query.OrderBy(orderBy, direction);

            return query
                .Where(spec)
                .ToListAsync();
        }

        public Task<List<TEntity>> QueryAll(int limitCount = RepositoryConstants.DefaultQueryLimitCount)
        {
            return this.Query()
                .Take(limitCount)
                .ToListAsync();
        }

        public Task<PagedResult<TEntity>> QueryPaged(PagedOptions pagedOptions)
        {
            if (pagedOptions == null)
                throw new ArgumentNullException(nameof(pagedOptions));

            var query = this.Query();

            if (!string.IsNullOrEmpty(pagedOptions.OrderBy))
                query = query.OrderBy(pagedOptions.OrderBy, pagedOptions.Direction);

            return query.ToPaged(pagedOptions.PageNumber, pagedOptions.PageSize, pagedOptions.IncludeTotalCount);
        }

        public Task<PagedResult<TEntity>> QueryPaged(PagedOptions pagedOptions, Expression<Func<TEntity, bool>> spec)
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

        public Task<bool> Exists()
        {
            return this.Query().AnyAsync();
        }

        public Task<bool> Exists(Expression<Func<TEntity, bool>> spec)
        {
            if (spec == null)
                throw new ArgumentNullException(nameof(spec));

            return this.Query().AnyAsync(spec);
        }

        public Task<long> Count()
        {
            return this.Query().LongCountAsync();
        }

        public Task<long> Count(Expression<Func<TEntity, bool>> spec)
        {
            if (spec == null)
                throw new ArgumentNullException(nameof(spec));

            return this.Query().LongCountAsync(spec);
        }

        public Task Insert(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return Task.Run(
                 () =>
                 {
                     this.dbContext.Entry(entity).State = EntityState.Added;
                 });
        }

        public Task Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return Task.Run(
                 () =>
                 {
                     this.dbContext.Entry(entity).State = EntityState.Modified;
                 });
        }

        public Task Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return Task.Run(
                 () =>
                 {
                     this.dbContext.Entry(entity).State = EntityState.Deleted;
                 });
        }

        protected Task ExecuteSqlCommand(string cmd)
        {
            return Task.Run(
                 () =>
                 {
                     this.dbContext.Database.ExecuteSqlCommand(cmd);
                     DataContextFactory.Clear();
                     var context = DataContextFactory.GetDataContext();
                     this.dbContext = context ?? throw new ArgumentNullException(nameof(context));
                     this.dbSet = this.dbContext.Set<TEntity>();
                 });
        }

        protected IQueryable<TEntity> Query()
        {
            return this.dbSet.AsNoTracking();
        }

        protected IQueryable<TEntity> QueryAsTracking()
        {
            return this.dbSet;
        }
    }
}
