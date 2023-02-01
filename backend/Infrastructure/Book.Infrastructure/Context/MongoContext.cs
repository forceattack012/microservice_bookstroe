using Book.Infrastructure.Data;
using Bookstore.Api.Enum.Book;
using MongoDB.Driver;

namespace Book.Infrastructure.Context
{
    public class MongoContext : IMongoContext
    {
        public MongoContext(string connection, string databaseName) 
        {
            var mongoClient = new MongoClient(connection);
            var mongoDatabase = mongoClient.GetDatabase(databaseName);
            var collection = mongoDatabase.GetCollection<Bookstore.Domain.Entities.Book>(BookDbSettings.COLLECTION_NAME);
            BookContextSeed.SeedData(collection);
            Collection = collection;
        }

        public IMongoCollection<Bookstore.Domain.Entities.Book> Collection { get; set; }
    }
}
