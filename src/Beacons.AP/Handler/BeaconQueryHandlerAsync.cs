using System.Threading.Tasks;
using Beacons.AP.Data;
using Beacons.AP.Query;
using MediatR;

namespace Beacons.AP.Handler
{
    /// <summary>
    /// Handler for Beacon Query
    /// </summary>
    public class BeaconQueryHandlerAsync : IAsyncRequestHandler<BeaconQuery, BeaconViewModel>
    {
        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public async Task<BeaconViewModel> Handle(BeaconQuery message)
        {
            // Could query a db here and get the columns we need.

            var viewModel = new BeaconViewModel
            {
                Id = 100,
                Number = "GFD123312"
            };

            return viewModel;
        }
    }
}
