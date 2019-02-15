using Domain.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Document
{
    public class DocumentRepository<TEntity, TKey> : IRepository<TEntity>, IMongoDriverClientAdapter
        where TEntity : BaseEntity<TKey>
    {
        private readonly IMongoClient mongoClient;
        private readonly IMongoDatabase mongoDatabase;
        private readonly Lazy<IMongoCollection<TEntity>> mongoCollection;

        public DocumentRepository(string connectionString)
        {
            var clientUrl = MongoUrl.Create(connectionString);
            var client = new MongoClient(clientUrl);

            this.mongoClient = client ?? throw new ArgumentNullException(nameof(client));

            this.mongoDatabase = client.GetDatabase(clientUrl?.DatabaseName ?? throw new ArgumentNullException(nameof(clientUrl)));

            this.mongoCollection = new Lazy<IMongoCollection<TEntity>>(() => this.GetCollection());
        }

        IMongoClient IMongoDriverClientAdapter.MongoClient => this.mongoClient;

        protected IMongoCollection<TEntity> Collection => this.mongoCollection.Value;

        protected IMongoDatabase Database => this.mongoDatabase;

        public Task<TEntity> Get(params object[] keys)
        {
            if (keys == null)
                throw new ArgumentNullException(nameof(keys));

            return this.Collection
                .Find(entity => entity.Codigo.Equals(keys.FirstOrDefault()))
                .FirstOrDefaultAsync();
        }

        public Task<TEntity> Get(Expression<Func<TEntity, bool>> spec)
        {
            if (spec == null)
                throw new ArgumentNullException(nameof(spec));

            return this.Collection
                .Find(spec)
                .FirstOrDefaultAsync();
        }

        public Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> spec)
        {
            if (spec == null)
                throw new ArgumentNullException(nameof(spec));

            return this.Collection
                .Find(spec)
                .ToListAsync();
        }

        public Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> spec, string orderBy, Domain.ValueObjects.SortDirection direction)
        {
            if (spec == null)
                throw new ArgumentNullException(nameof(spec));

            var query = this.Collection.Find(spec);
            if (!string.IsNullOrEmpty(orderBy))
                query = query.SortBy(orderBy, (SortDirection)direction);

            return query.ToListAsync();
        }

        public Task<List<TEntity>> QueryAll(int limitCount = RepositoryConstants.DefaultQueryLimitCount)
        {
            return this.Collection
                .Find(new BsonDocument())
                .Limit(limitCount)
                .ToListAsync();
        }

        public Task<PagedResult<TEntity>> QueryPaged(PagedOptions pagedOptions)
        {
            if (pagedOptions == null)
                throw new ArgumentNullException(nameof(pagedOptions));

            var find = this.Collection.Find(new BsonDocument());

            if (!string.IsNullOrWhiteSpace(pagedOptions.OrderBy))
                find = find.SortBy(pagedOptions.OrderBy, (SortDirection)pagedOptions.Direction);

            return find.ToPagedAsync(pagedOptions.PageNumber, pagedOptions.PageSize, pagedOptions.IncludeTotalCount);
        }

        public Task<PagedResult<TEntity>> QueryPaged(PagedOptions pagedOptions, Expression<Func<TEntity, bool>> spec)
        {
            if (pagedOptions == null)
                throw new ArgumentNullException(nameof(pagedOptions));

            if (spec == null)
                throw new ArgumentNullException(nameof(spec));

            var find = this.Collection.Find(spec);

            if (!string.IsNullOrWhiteSpace(pagedOptions.OrderBy))
                find = find.SortBy(pagedOptions.OrderBy, (SortDirection)pagedOptions.Direction);

            return find.ToPagedAsync(pagedOptions.PageNumber, pagedOptions.PageSize, pagedOptions.IncludeTotalCount);
        }

        public Task<bool> Exists()
        {
            return this.Collection
                .Find(new BsonDocument())
                .AnyAsync();
        }

        public Task<bool> Exists(Expression<Func<TEntity, bool>> spec)
        {
            if (spec == null)
                throw new ArgumentNullException(nameof(spec));

            return this.Collection
                .Find(spec)
                .AnyAsync();
        }

        public Task<long> Count()
        {
            return this.Collection
                .Find(new BsonDocument())
                .CountDocumentsAsync();
        }

        public Task<long> Count(Expression<Func<TEntity, bool>> spec)
        {
            if (spec == null)
                throw new ArgumentNullException(nameof(spec));

            return this.Collection
                .Find(spec)
                .CountDocumentsAsync();
        }

        public Task Insert(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return this.Collection.InsertOneAsync(entity);
        }

        public Task Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return this.Collection.ReplaceOneAsync(
                filterEntity => filterEntity.Codigo.Equals(entity.Codigo),
                entity);
        }

        public Task Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return this.Collection.DeleteOneAsync(filterEntity => filterEntity.Codigo.Equals(entity.Codigo));
        }

        private IMongoCollection<TEntity> GetCollection() => this.mongoDatabase.GetCollection<TEntity>(typeof(TEntity).Name);
    }
}
