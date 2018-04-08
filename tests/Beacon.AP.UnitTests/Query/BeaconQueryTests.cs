using Beacons.AP.Query;
using Moq;
using System;
using System.Threading.Tasks;
using Beacons.AP.Handler;
using Beacons.AP.Model;
using FluentAssertions;
using Xunit;

namespace Beacon.AP.UnitTests.Query
{
    public class BeaconQueryTests : IDisposable
    {
        private readonly MockRepository mockRepository;

        public BeaconQueryTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        public void Dispose()
        {
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task HandlerReturnsCorrectUserViewModel()
        {
            // Arrange
            var beaconQueryHandlerAsync = new BeaconQueryHandlerAsync();

            var beaconQuery = new BeaconQuery { Id = 1 };

            // Act
            BeaconViewModel beaconViewModel = await beaconQueryHandlerAsync.Handle(beaconQuery);

            // Assert
            beaconViewModel.Should().NotBeNull();
        }
    }
}
