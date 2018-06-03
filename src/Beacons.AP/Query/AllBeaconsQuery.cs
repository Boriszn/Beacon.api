using System.Collections.Generic;
using Beacons.AP.Model;
using MediatR;

namespace Beacons.AP.Query
{
    public class AllBeaconsQuery : IAsyncRequest<List<BeaconViewModel>>
    {
        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        /// <value>
        /// The page.
        /// </value>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the page count.
        /// </summary>
        /// <value>
        /// The page count.
        /// </value>
        public int PageCount { get; set; }
    }
}