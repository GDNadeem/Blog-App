using Blog_App.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Blog_App.Services
{
    public class LoginService
    {
        private readonly IMongoCollection<Login> logincollection;

        public LoginService(IOptions<LoginDatabaseSettings> logindatabasesettings)
        {
            var mongoclient = new MongoClient(logindatabasesettings.Value.ConnectionString);

            var mongodatabase = mongoclient.GetDatabase(logindatabasesettings.Value.DatabaseName);

            logincollection = mongodatabase.GetCollection<Login>(logindatabasesettings.Value.LoginCollectionName);
        }

        public async Task<List<Login>> GetAsync() =>
            await logincollection.Find(_ => true).ToListAsync();

        public async Task CreateAsync(Login newLogin) =>
            await logincollection.InsertOneAsync(newLogin);

    }
}
