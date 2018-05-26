using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Beacons.AP.Data.BeaconsDb.Model;

namespace Beacons.AP.Data.BeaconsDb.Repositories
{
    public interface IBeaconsRepository
    {
        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Beacon>> GetAllAsync();

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <param name="currentPage">The current page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        Task<IEnumerable<Beacon>> GetAllAsync(int currentPage, int pageSize);

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<Beacon> GetAsync(string id);

        /// <summary>
        /// Finds the by.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        Task<Beacon> FindBy(Expression<Func<Beacon, bool>> predicate);

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Beacon Get(string id);

        /// <summary>
        /// Inserts the specified tenant configuration model.
        /// </summary>
        /// <param name="tenantConfigurationModel">The tenant configuration model.</param>
        /// <returns></returns>
        Task Insert(Beacon tenantConfigurationModel);

        /// <summary>
        /// Updates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="tenantConfigurationModel">The tenant configuration model.</param>
        /// <returns></returns>
        Beacon Update(string id, Beacon tenantConfigurationModel);
    }
}