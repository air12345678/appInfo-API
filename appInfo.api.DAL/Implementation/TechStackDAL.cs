using appInfo.api.common.models;
using appInfo.API.DAL.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace appInfo.api.DAL.Implementation
{
    public class TechStackDAL : ITechStackDAL
    {
        private readonly IMongoCollection<TechStack> _techStackCollection;
        private readonly IOptions<AppInfoDatabaseSettings> _dbSettings;
        public TechStackDAL(IOptions<AppInfoDatabaseSettings> appInfoDatabaseSettings)
        {
            _dbSettings = appInfoDatabaseSettings;
            var mongoClient = new MongoClient(appInfoDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(appInfoDatabaseSettings.Value.DatabaseName);
            _techStackCollection = mongoDatabase.GetCollection<TechStack>
                (appInfoDatabaseSettings.Value.TechStackCollectionName);
        }
        public async Task<List<TechStack>> GetAll()
        {
            var ReturnVal = new List<TechStack>();
            ReturnVal = await _techStackCollection.Find(x => true).ToListAsync();
            return ReturnVal;
        }

    }

}