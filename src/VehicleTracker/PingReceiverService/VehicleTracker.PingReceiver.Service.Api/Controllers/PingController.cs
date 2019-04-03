using System;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using VehicleTracker.Abstract.Domain.Core.Bus;
using VehicleTracker.Abstract.Domain.Core.Notifications;
using VehicleTracker.PingReceiver.Application.Interfaces;
using VehicleTracker.PingReceiver.Application.ViewModels;

namespace VehicleTracker.PingReceiver.Service.Api.Controllers
{
    public class PingController : BaseApiController
    {
        private readonly IPingAppService _pingAppService;

        public PingController(
            IPingAppService pingAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _pingAppService = pingAppService;
        }



        [HttpPost]
        [SwaggerOperation(OperationId = "Ping")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, Description = "response of adding Ping")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest, Description = "Invalid parameters")]
        public async Task<IActionResult> Post([FromBody]PingViewModel pingViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(pingViewModel);
            }

            await _pingAppService.SendPingMessageAsync(pingViewModel);

            return Response(pingViewModel);
        }

    }
}
