using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehicleTracker.Abstract.Domain.Core.Bus;
using VehicleTracker.Abstract.Domain.Core.Notifications;
using VehicleTracker.PingReceiver.Application.Interfaces;
using VehicleTracker.PingReceiver.Application.ViewModels;
using VehicleTracker.PingReceiver.Service.Api.Controllers;

namespace VehicleTracker.PingReceiver.Tests
{
    [TestClass]
    public class PingControllerTests : TestsBase
    {
        private static PingController _pingController;
        private static Mock<IPingAppService> _pingAppService;
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
            _pingAppService = new Mock<IPingAppService>();

            _pingAppService.Setup(appService => appService.SendPingMessageAsync(It.IsAny<PingViewModel>())).Returns(Task.CompletedTask).Verifiable();
            _notifications = new Mock<DomainNotificationHandler>().Object;
            _mediator = new Mock<IMediatorHandler>().Object;

            _pingController = new PingController(_pingAppService.Object, _notifications, _mediator);
        }



        [TestMethod]
        public void TestPingVehicle()
        {
            // Arrange
            var pingViewModel = new PingViewModel
            {
                VehicleId = "YS2R4X20005399401"
            };

            // Act
            var result = _pingController.Post(pingViewModel).Result;
            var okResult = result as OkObjectResult;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}
