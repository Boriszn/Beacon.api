using Beacons.AP.Configuration.Settings;
using Beacons.AP.Data.BeaconsDb.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Beacons.AP.Data.BeaconsDb.Infrastructure
{
    public class BeaconsDbContext : IBeaconsDbContext
    {
        private const string BeaconCollection = "Beacons";
        private readonly IMongoDatabase database;

        /// <summary>
        /// Initializes a new instance of the <see cref="BeaconsDbContext"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public BeaconsDbContext(IOptions<MongoConfigurationSettings> settings)
        {
            IMongoClient client = new MongoClient(settings.Value.ConnectionString);
            this.database = client.GetDatabase(settings.Value.Database);
        }

        /// <inheritdoc />
        public IMongoCollection<Beacon> Beacons => this.database.GetCollection<Beacon>(BeaconCollection);
    }
}
