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
    public class CustomerController : BaseApiController
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(
            ICustomerAppService customerAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _customerAppService = customerAppService;
        }
        
        [HttpGet]
        [SwaggerOperation(OperationId = "GelAllCustomers")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, Type = typeof(IEquatable<CustomerViewModel>))]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest, Description = "Invalid parameters")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.NotFound, Description = "Posts not found")]
        public IActionResult Get()
        {
            return Response(_customerAppService.GetAll());
        }

        [HttpGet]
        [Route("{id:guid}")]
        [SwaggerOperation(OperationId = "GetCustomer")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, Type = typeof(CustomerViewModel))]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest, Description = "Invalid parameters")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.NotFound, Description = "the blog post not found")]
        public IActionResult Get(Guid id)
        {
            var postViewModel = _customerAppService.GetById(id);

            return Response(postViewModel);
        }

        [HttpPost]
        [SwaggerOperation(OperationId = "AddNewCustomer")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, Description = "response of adding new post")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest, Description = "Invalid parameters")]
        public IActionResult Post([FromBody]CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(customerViewModel);
            }

            _customerAppService.AddNewCustomer(customerViewModel);

            return Response(customerViewModel);
        }

        [HttpPut]
        [SwaggerOperation(OperationId = "UpdateCustomer")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, Description = "response of updating a post")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest, Description = "Invalid parameters")]
        public IActionResult Put([FromBody]CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(customerViewModel);
            }

            _customerAppService.Update(customerViewModel);

            return Response(customerViewModel);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [SwaggerOperation(OperationId = "RemoveCustomer")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, Description = "response of deleting a post")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest, Description = "Invalid parameters")]
        public IActionResult Delete(Guid id)
        {
            _customerAppService.Remove(id);

            return Response();
        }

    }
}
