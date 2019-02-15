using MongoDB.Driver;

namespace Infrastructure.Repositories.Document
{
    public interface IMongoDriverClientAdapter
    {
        IMongoClient MongoClient { get; }
    }
}
