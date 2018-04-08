using MediatR;
using Moq;
using System.Threading.Tasks;
using Beacon.AP.UnitTests.Builders;
using Beacons.AP.Model;
using Beacons.AP.Query;
using Beacons.AP.Services;
using FluentAssertions;
using Xunit;

namespace Beacon.AP.UnitTests.Services
{
    public class BeaconServiceTests
    {
        private readonly MockRepository mockRepository;
        private Mock<IMediator> mockMediator;
        private readonly BeaconServiceBuilder beaconServiceBuilder;

        public BeaconServiceTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockMediator = this.mockRepository.Create<IMediator>();

            this.beaconServiceBuilder = new BeaconServiceBuilder();
        }

        [Fact]
        public async void GetById_SendsQueryWithTheCorrectUserId_Verify()
        {
            // Arrange
            const int userId = 1;

            this.mockMediator = new Mock<IMediator>();
            var beaconService = new BeaconService(this.mockMediator.Object);

            // Act
            await beaconService.GetById(userId);

            // Assert
            this.mockMediator.Verify(x => x.SendAsync(It.Is<BeaconQuery>(y => y.Id == userId)), Times.Once);
        }

        [Fact]
        public async void GetById_WithProperUserId_ReturnsBeaconViewModel()
        {
            // Arrange
            const int userId = 1;

            var beaconViewModel = new BeaconViewModel
            {
                Id = 2123
            };

            BeaconService beaconService = beaconServiceBuilder
                .WithBeaconViewModel(beaconViewModel)
                .Build();

            // Act
            BeaconViewModel beaconViewModelResult =  await beaconService.GetById(userId);

            // Assert
            beaconViewModelResult.Should().NotBeNull();
            beaconViewModelResult.Id.Should().Be(beaconViewModel.Id);
        }
    }
}
