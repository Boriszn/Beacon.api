using System;
using System.Threading.Tasks;
using Beacons.AP.Data;
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

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<BeaconViewModel> GetById(int id)
        {
            BeaconViewModel beaconViewModel = await mediator.SendAsync(new BeaconQuery { Id = id });

            return beaconViewModel;
        }
    }
}
