using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Core
{
    public abstract class BaseEntity<TKey> : IEntity<TKey>, IDto
    {
        protected BaseEntity()
        {
        }

        [BsonId]
        public TKey Codigo { get; protected set; }
    }
}
