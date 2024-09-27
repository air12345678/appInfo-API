using appInfo.api.common.models;
using appInfo.API.DAL.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;


namespace appInfo.api.DAL.Implementation
{
    public class ApplicationInfoDetailDAL : IApplicationDetailDAL
    {
        private readonly IMongoCollection<ApplicationInfoDataSetWithDto> _applicationInfoCollection;
        private readonly IOptions<AppInfoDatabaseSettings> _dbSettings;
        public ApplicationInfoDetailDAL(IOptions<AppInfoDatabaseSettings> appInfoDatabaseSettings)
        {
            _dbSettings = appInfoDatabaseSettings;
            var mongoClient = new MongoClient(appInfoDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(appInfoDatabaseSettings.Value.DatabaseName);
            _applicationInfoCollection =mongoDatabase.GetCollection<ApplicationInfoDataSetWithDto>
                (appInfoDatabaseSettings.Value.ApplicationInfoCollectionName);
        }
        public async Task AddApplicationDetails(ApplicationInfoDataSetWithDto detailParams)
        {
            try
            {
                await _applicationInfoCollection.InsertOneAsync(detailParams);
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex);
            }
        }

        public async Task<List<ApplicationInfoDataSetWithDto>> GetAllApplicationDetails()
        {
            var returnVal = await _applicationInfoCollection.Find(x=>true).ToListAsync();
            return returnVal;
        }
    }

}