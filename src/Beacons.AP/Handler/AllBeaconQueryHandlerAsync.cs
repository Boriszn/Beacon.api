using System;
using System.Collections.Generic;
using System.Linq;
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
    public class AllBeaconQueryHandlerAsync : IAsyncRequestHandler<AllBeaconsQuery, List<BeaconViewModel>>
    {
        private readonly IBeaconsRepository beaconsRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BeaconQueryHandlerAsync"/> class.
        /// </summary>
        /// <param name="beaconsRepository">The beacons repository.</param>
        public AllBeaconQueryHandlerAsync(IBeaconsRepository beaconsRepository)
        {
            this.beaconsRepository = beaconsRepository;
        }

        public async Task<List<BeaconViewModel>> Handle(AllBeaconsQuery message)
        {
            IEnumerable<Beacon> beacons = await beaconsRepository.GetAllAsync();

            var beaconsViewModel = beacons.Select(r => new BeaconViewModel()
            {
                Id = Guid.Parse(r.BeaconId),
                Number = r.Title
            });

            return beaconsViewModel.ToList();
        }
    }
}