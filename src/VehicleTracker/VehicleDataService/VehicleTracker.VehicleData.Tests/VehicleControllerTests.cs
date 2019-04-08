using System;
using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VehicleTracker.Abstract.Domain.Core.Bus;
using VehicleTracker.Abstract.Domain.Core.Notifications;
using VehicleTracker.VehicleData.Application.Interfaces;
using VehicleTracker.VehicleData.Application.Services;
using VehicleTracker.VehicleData.Application.ViewModels;
using VehicleTracker.VehicleData.Domain.Models;
using VehicleTracker.VehicleData.Service.Api.Controllers;

namespace VehicleTracker.VehicleData.Tests
{
    [TestClass]
    public class VehicleControllerTests : TestsBase
    {

        private static VehicleController _vehicleController;
        private static Mock<IVehicleAppService> _vehicleAppService;
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
            _vehicleAppService = new Mock<IVehicleAppService>();
            _vehicleAppService.Setup(appService => appService.GetAll()).Returns(GetVehiclesViewModel);
            _notifications = new Mock<DomainNotificationHandler>().Object;
            _mediator = new Mock<IMediatorHandler>().Object;

            _vehicleController = new VehicleController(_vehicleAppService.Object, _notifications, _mediator);
        }


        [TestMethod]
        public void TestGetAllVehicles()
        {
            // Act
            var result = _vehicleController.Get();
            var okResult = result as OkObjectResult;

            // assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }



        private List<VehicleViewModel> GetVehiclesViewModel()
        {
            var list = new List<VehicleViewModel>
            {
                new VehicleViewModel
                {
                    Id = new Guid("40000a0b-ddd6-44c0-8f19-963e5ca783dd"),
                    VehicleId = "YS2R4X20005399401",
                    RegNumber = "ABC123",
                    CustomerId = new Guid("10000a0b-ddd6-44c0-8f19-963e5ca783dd")
                },
                new VehicleViewModel
                {
                    Id = new Guid("50000a0b-ddd6-44c0-8f19-963e5ca783dd"),
                    VehicleId = "VLUR4X20009093588",
                    RegNumber = "DEF456",
                    CustomerId = new Guid("10000a0b-ddd6-44c0-8f19-963e5ca783dd")
                },
                new VehicleViewModel
                {
                    Id = new Guid("60000a0b-ddd6-44c0-8f19-963e5ca783dd"),
                    VehicleId = "VLUR4X20009048066",
                    RegNumber = "GHI789",
                    CustomerId = new Guid("10000a0b-ddd6-44c0-8f19-963e5ca783dd")
                },
                new VehicleViewModel
                {
                    Id = new Guid("70000a0b-ddd6-44c0-8f19-963e5ca783dd"),
                    VehicleId = "YS2R4X20005388011",
                    RegNumber = "JKL012",
                    CustomerId = new Guid("20000a0b-ddd6-44c0-8f19-963e5ca783dd")
                },
                new VehicleViewModel
                {
                    Id = new Guid("80000a0b-ddd6-44c0-8f19-963e5ca783dd"),
                    VehicleId = "YS2R4X20005387949",
                    RegNumber = "MNO345",
                    CustomerId = new Guid("20000a0b-ddd6-44c0-8f19-963e5ca783dd")
                },
                new VehicleViewModel
                {
                    Id = new Guid("90000a0b-ddd6-44c0-8f19-963e5ca783dd"),
                    VehicleId = "VLUR4X20009048066",
                    RegNumber = "PQR678",
                    CustomerId = new Guid("30000a0b-ddd6-44c0-8f19-963e5ca783dd")
                },
                new VehicleViewModel
                {
                    Id = new Guid("01000a0b-ddd6-44c0-8f19-963e5ca783dd"),
                    VehicleId = "YS2R4X20005387055",
                    RegNumber = "STU901",
                    CustomerId = new Guid("30000a0b-ddd6-44c0-8f19-963e5ca783dd")
                }
            };
            return list;
        }


    }
}
