using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Beacons.AP.Model;
using Beacons.AP.Query;
using MediatR;

namespace Beacons.AP.Services
{
    /// <summary>
    /// Beacon service
    /// </summary>
    public class BeaconService : IBeaconService
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="BeaconService"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        /// <exception cref="ArgumentNullException">mediator</exception>
        public BeaconService(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <inheritdoc />
        public async Task<List<BeaconViewModel>> GetAll()
        {
            var beaconViewModel = await mediator.SendAsync(new AllBeaconsQuery
            {
                Page = 1,
                PageCount = 5
            });

            return beaconViewModel;
        }

        /// <inheritdoc />
        public async Task<BeaconViewModel> GetById(Guid id)
        {
            BeaconViewModel beaconViewModel = await mediator.SendAsync(new BeaconQuery { Id = id });

            return beaconViewModel;
        }
    }
}
