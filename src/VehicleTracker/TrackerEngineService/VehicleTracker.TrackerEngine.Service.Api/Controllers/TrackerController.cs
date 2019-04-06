using System;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using VehicleTracker.Abstract.Domain.Core.Bus;
using VehicleTracker.Abstract.Domain.Core.Notifications;
using VehicleTracker.TrackerEngine.Application.EventSourcedNormalizers;
using VehicleTracker.TrackerEngine.Application.Interfaces;
using VehicleTracker.TrackerEngine.Application.ViewModels;

namespace VehicleTracker.TrackerEngine.Service.Api.Controllers
{
    [Route("[controller]")]
    public class TrackerController : BaseApiController
    {
        private readonly IVehiclePingAppService _vehiclePingAppService;

        public TrackerController(
            IVehiclePingAppService vehiclePingAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _vehiclePingAppService = vehiclePingAppService;
        }


        [HttpPost]
        [SwaggerOperation(OperationId = "ReceivePing")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, Description = "response of receiving ping")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest, Description = "Invalid parameters")]
        public IActionResult Post([FromBody]VehiclePingViewModel vehiclePingViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(vehiclePingViewModel);
            }

             _vehiclePingAppService.ReceivePingMessage(vehiclePingViewModel);

            return Response(vehiclePingViewModel);
        }


        [HttpGet]
        [Route("VehiclesStatus")]
        [SwaggerOperation(OperationId = "GetVehiclesStatus")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, Type = typeof(IEquatable<VehiclePingHistory>))]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest, Description = "Invalid parameters")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.NotFound, Description = "the Vehicle Ping History not found")]
        public IActionResult GetStatus()
        {
            var vehicleHistoryData = _vehiclePingAppService.GetAllVehiclesConnectionStatus();

            return Response(vehicleHistoryData);
        }



        [HttpGet]
        [Route("VehiclePingHistory/{id:guid}")]
        [SwaggerOperation(OperationId = "GetVehiclePingHistory")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, Type = typeof(VehiclePingHistory))]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest, Description = "Invalid parameters")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.NotFound, Description = "the Vehicle Ping History not found")]
        public IActionResult History(Guid id)
        {
            var vehicleHistoryData = _vehiclePingAppService.GetAllHistory(id);

            return Response(vehicleHistoryData);
        }
    }
}
