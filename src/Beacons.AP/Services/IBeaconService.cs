using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Beacons.AP.Model;

namespace Beacons.AP.Services
{
    /// <summary>
    /// Interface of Beacon service 
    /// </summary>
    public interface IBeaconService
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>Beacon View Model List</returns>
        Task<List<BeaconViewModel>> GetAll();

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<BeaconViewModel> GetById(Guid id);
    }
}