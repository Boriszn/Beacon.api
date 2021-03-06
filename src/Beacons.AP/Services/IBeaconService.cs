﻿using System;
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
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<BeaconViewModel> GetById(Guid id);
    }
}