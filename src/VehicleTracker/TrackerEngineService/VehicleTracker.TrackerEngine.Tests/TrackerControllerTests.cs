using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VehicleTracker.Abstract.Domain.Core.Bus;
using VehicleTracker.Abstract.Domain.Core.Notifications;
using VehicleTracker.TrackerEngine.Application.Interfaces;
using VehicleTracker.TrackerEngine.Application.Services;
using VehicleTracker.TrackerEngine.Application.ViewModels;
using VehicleTracker.TrackerEngine.Service.Api.Controllers;

namespace VehicleTracker.TrackerEngine.Tests
{
    [TestClass]
    public class TrackerControllerTests : TestsBase
    {
        private static TrackerController _trackerController;
        private static Mock<IVehiclePingAppService> _vehiclePingAppService;
        private static INotificationHandler<DomainNotification> _notifications;
        private static IMediatorHandler _mediator;

        [ClassInitialize]
        public static void BeforeAllTests(TestContext context)
        {


        }

        [TestInitialize]
        public void BeforeEachTest()
        {
            // Arrange
            _vehiclePingAppService = new Mock<IVehiclePingAppService>();

            _vehiclePingAppService.Setup(appService => appService.ReceivePingMessage(It.IsAny<VehiclePingViewModel>()))
                .Verifiable();
            _notifications = new Mock<DomainNotificationHandler>().Object;
            _mediator = new Mock<IMediatorHandler>().Object;

            _trackerController = new TrackerController(_vehiclePingAppService.Object, _notifications, _mediator);

        }

        [TestMethod]
        public void TestPingVehicle()
        {
            // Arrange
            var vehiclePingViewModel = new VehiclePingViewModel
            {
                VehicleId = "YS2R4X20005399401",
                PingTime = DateTime.UtcNow,
                Id = new Guid("40000a0b-ddd6-44c0-8f19-963e5ca783dd")
            };

            // Act
            var result = _trackerController.Post(vehiclePingViewModel);
            var okResult = result as OkObjectResult;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}
