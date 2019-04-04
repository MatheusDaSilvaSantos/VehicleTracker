using System;
using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using VehicleTracker.Abstract.Domain.Core.Bus;
using VehicleTracker.Abstract.Domain.Core.Notifications;
using VehicleTracker.VehicleData.Application.Interfaces;
using VehicleTracker.VehicleData.Application.ViewModels;

namespace VehicleTracker.VehicleData.Service.Api.Controllers
{
    [Route("[controller]")]
    public class VehicleController : BaseApiController
    {
        private readonly IVehicleAppService _vehicleAppService;

        public VehicleController(
            IVehicleAppService vehicleAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _vehicleAppService = vehicleAppService;
        }

        [HttpGet]
        [SwaggerOperation(OperationId = "GelAllVehicles")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, Type = typeof(IEquatable<VehicleViewModel>))]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest, Description = "Invalid parameters")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.NotFound, Description = "Posts not found")]
        public IActionResult Get()
        {
            return Response(_vehicleAppService.GetAll());
        }

        [HttpGet]
        [Route("{id:guid}")]
        [SwaggerOperation(OperationId = "GetVehicle")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, Type = typeof(VehicleViewModel))]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest, Description = "Invalid parameters")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.NotFound, Description = "the blog post not found")]
        public IActionResult Get(Guid id)
        {
            var postViewModel = _vehicleAppService.GetById(id);

            return Response(postViewModel);
        }

        [HttpPost]
        [SwaggerOperation(OperationId = "AddNewVehicle")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, Description = "response of adding new post")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest, Description = "Invalid parameters")]
        public IActionResult Post([FromBody]VehicleViewModel vehicleViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(vehicleViewModel);
            }

            _vehicleAppService.AddNewVehicle(vehicleViewModel);

            return Response(vehicleViewModel);
        }

        [HttpPut]
        [SwaggerOperation(OperationId = "UpdateVehicle")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, Description = "response of updating a post")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest, Description = "Invalid parameters")]
        public IActionResult Put([FromBody]VehicleViewModel vehicleViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(vehicleViewModel);
            }

            _vehicleAppService.Update(vehicleViewModel);

            return Response(vehicleViewModel);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [SwaggerOperation(OperationId = "RemoveVehicle")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, Description = "response of deleting a post")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest, Description = "Invalid parameters")]
        public IActionResult Delete(Guid id)
        {
            _vehicleAppService.Remove(id);

            return Response();
        }

    }
}