using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebApi_MongoDB.Models;

namespace WebApi_MongoDB.Services
{
    public class NoSqlService
    {
        private readonly IMongoCollection<Contact> _contactsCollection;

        public NoSqlService(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _contactsCollection = mongoDatabase.GetCollection<Contact>(databaseSettings.Value.ContactCollectionName);
        }

        public async Task CreateAsync(Contact contact)
        {
            await _contactsCollection.InsertOneAsync(contact);
        }
            
    }
}
