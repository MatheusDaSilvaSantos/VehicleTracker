

using System;
using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VehicleTracker.Abstract.Domain.Core.Bus;
using VehicleTracker.Abstract.Domain.Core.Notifications;
using VehicleTracker.VehicleData.Application.Interfaces;
using VehicleTracker.VehicleData.Application.ViewModels;
using VehicleTracker.VehicleData.Service.Api.Controllers;

namespace VehicleTracker.VehicleData.Tests
{
    [TestClass]
    public class CustomerControllerTests : TestsBase
    {

        private static CustomerController _customerController;
        private static Mock<ICustomerAppService> _customerAppService;
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
            _customerAppService = new Mock<ICustomerAppService>();
            _customerAppService.Setup(appService => appService.GetAll()).Returns(GetCustomersViewModel);
            _notifications = new Mock<DomainNotificationHandler>().Object;
            _mediator = new Mock<IMediatorHandler>().Object;

            _customerController = new CustomerController(_customerAppService.Object, _notifications, _mediator);
        }


        [TestMethod]
        public void TestGetAllCustomers()
        {
            // Act
            var result = _customerController.Get();
            var okResult = result as OkObjectResult;

            // assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }



        private List<CustomerViewModel> GetCustomersViewModel()
        {
            var list = new List<CustomerViewModel>
            {
                new CustomerViewModel
                {
                    Id = new Guid("10000a0b-ddd6-44c0-8f19-963e5ca783dd"),
                    Name = "Kalles Grustransporter AB",
                    Address = "Cementvägen 8, 111 11 Södertälje"
                },
                new CustomerViewModel
                {
                    Id = new Guid("20000a0b-ddd6-44c0-8f19-963e5ca783dd"),
                    Name = "Johans Bulk AB  ",
                    Address = "Balkvägen 12, 222 22 Stockholm "
                }

            };
            return list;
        }

    }
}