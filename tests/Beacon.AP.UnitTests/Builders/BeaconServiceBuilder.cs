using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Beacons.AP.Model;
using Beacons.AP.Query;
using Beacons.AP.Services;
using MediatR;
using Moq;

namespace Beacon.AP.UnitTests.Builders
{
    public class BeaconServiceBuilder
    {
        private readonly Mock<IMediator> mockMediator;
        private readonly MockRepository mockRepository;

        public BeaconServiceBuilder()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.mockMediator = this.mockRepository.Create<IMediator>();
        }

        public BeaconServiceBuilder WithBeaconViewModel(BeaconViewModel beaconViewModel)
        {
            this.mockMediator.Setup(x => x.SendAsync(It.IsAny<BeaconQuery>())).Returns(Task.FromResult(beaconViewModel));

            return this;
        }

        public BeaconService Build()
        {
            return new BeaconService(this.mockMediator.Object);
        }
    }
}
