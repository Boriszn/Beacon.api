﻿using Beacons.AP.Data;
using MediatR;

namespace Beacons.AP.Query
{
    /// <summary>
    /// Beacon query class
    /// </summary>
    /// <seealso cref="MediatR.IAsyncRequest{ BeaconViewModel }" />
    public class BeaconQuery : IAsyncRequest<BeaconViewModel>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
    }
}
