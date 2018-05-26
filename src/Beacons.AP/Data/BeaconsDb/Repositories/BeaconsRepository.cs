using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Beacons.AP.Data.BeaconsDb.Infrastructure;
using Beacons.AP.Data.BeaconsDb.Model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Beacons.AP.Data.BeaconsDb.Repositories
{
    public class BeaconsRepository : IBeaconsRepository
    {
        private readonly IBeaconsDbContext dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="BeaconsRepository" /> class.
        /// </summary>
        /// <param name="configDbContext">The settings.</param>
        public BeaconsRepository(IBeaconsDbContext configDbContext)
        {
            this.dbContext = configDbContext;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Beacon>> GetAllAsync()
        {
            return await this.dbContext.Beacons
                .Find(_ => true)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Beacon>> GetAllAsync(int currentPage, int pageSize)
        {
            return await this.dbContext.Beacons
                .Find(_ => true)
                .Skip((currentPage - 1) * pageSize)
                .Limit(pageSize)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<Beacon> GetAsync(string id)
        {
            var filter = Builders<Beacon>.Filter.Eq("Id", id);

            return await this.dbContext.Beacons
                .Find(filter)
                .FirstOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<Beacon> FindBy(Expression<Func<Beacon, bool>> predicate)
        {
            return await this.dbContext.Beacons
                .Find(predicate)
                .FirstOrDefaultAsync();
        }

        /// <inheritdoc/>
        public Beacon Get(string id)
        {
            return this.dbContext.Beacons.Find(new BsonDocument { { "_id", new ObjectId(id) } }).FirstAsync().Result;
        }

        /// <inheritdoc/>
        public async Task Insert(Beacon tenantConfigurationModel)
        {
            await this.dbContext.Beacons.InsertOneAsync(tenantConfigurationModel);
        }

        /// <inheritdoc/>
        public Beacon Update(string id, Beacon tenantConfigurationModel)
        {
            var filter = Builders<Beacon>.Filter.Eq(s => s.Id, tenantConfigurationModel.Id);
            this.dbContext.Beacons.ReplaceOneAsync(filter, tenantConfigurationModel);
            return this.Get(id);
        }
    }
}
