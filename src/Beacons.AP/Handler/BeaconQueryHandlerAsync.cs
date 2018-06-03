using System;
using System.Threading.Tasks;
using Beacons.AP.Data.BeaconsDb.Model;
using Beacons.AP.Data.BeaconsDb.Repositories;
using Beacons.AP.Model;
using Beacons.AP.Query;
using MediatR;

namespace Beacons.AP.Handler
{
    /// <summary>
    /// Handler for Beacon Query
    /// </summary>
    public class BeaconQueryHandlerAsync : IAsyncRequestHandler<BeaconQuery, BeaconViewModel>
    {
        private readonly IBeaconsRepository beaconsRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BeaconQueryHandlerAsync"/> class.
        /// </summary>
        /// <param name="beaconsRepository">The beacons repository.</param>
        public BeaconQueryHandlerAsync(IBeaconsRepository beaconsRepository)
        {
            this.beaconsRepository = beaconsRepository;
        }

        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public async Task<BeaconViewModel> Handle(BeaconQuery message)
        {
            Beacon beacon = await beaconsRepository.FindBy(m => m.BeaconId == message.Id.ToString());

            //TODO: add auto mapper
            var viewModel = new BeaconViewModel
            {
                Id = Guid.Parse(beacon.BeaconId),
                Number = beacon.Title
            };

            return await Task.FromResult(viewModel);
        }
    }
}
