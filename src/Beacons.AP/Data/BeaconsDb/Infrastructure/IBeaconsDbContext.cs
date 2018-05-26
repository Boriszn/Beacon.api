using Beacons.AP.Data.BeaconsDb.Model;
using MongoDB.Driver;

namespace Beacons.AP.Data.BeaconsDb.Infrastructure
{
    public interface IBeaconsDbContext
    {
        /// <summary>
        /// Gets the tenant configurations.
        /// </summary>
        /// <value>
        /// The tenant configurations.
        /// </value>
        IMongoCollection<Beacon> Beacons { get; }
    }
}