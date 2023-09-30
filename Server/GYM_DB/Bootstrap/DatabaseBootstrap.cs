using GYM_DB.Bootstrap;
using GYM_MODELS.DB;
using GYM_MODELS.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace DatabaseBootstrapLibrary
{
    public static class DatabaseBootstrap
    {
        public static void Initialize(IServiceCollection services, IConfiguration configuration)
        {
            MongoDBSettings? mongoDbSettings = configuration.GetSection("MongoDB").Get<MongoDBSettings>();
            services.AddSingleton<IMongoClient>(serviceProvider => new MongoClient(mongoDbSettings.ConnectionString));
            services.AddSingleton(serviceProvider => serviceProvider.GetRequiredService<IMongoClient>().GetDatabase(mongoDbSettings.DatabaseName));

            DatabaseModelsBsonMapper.Initialize();
            RepositoryBootstrap.Initialize(services);
        }
    }
}
