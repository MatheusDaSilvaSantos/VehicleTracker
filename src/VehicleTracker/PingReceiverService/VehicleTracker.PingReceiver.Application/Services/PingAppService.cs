using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleTracker.PingReceiver.Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using VehicleTracker.Abstract.Domain.Core.Bus;
using VehicleTracker.PingReceiver.Application.ViewModels;
using VehicleTracker.PingReceiver.Domain.Commands;
using VehicleTracker.PingReceiver.Domain.Interfaces;

namespace VehicleTracker.PingReceiver.Application.Services
{
    public class PingAppService : IPingAppService
    {
        private readonly IMapper _mapper;
        private readonly ISendMessagesService _sendMessagesService;
        private readonly IMediatorHandler Bus;

        public PingAppService(IMapper mapper,
                                  ISendMessagesService sendMessagesService,
                                  IMediatorHandler bus)
        {
            _mapper = mapper;
            _sendMessagesService = sendMessagesService;
            Bus = bus;

        }

       
        public Task SendPingMessageAsync(PingViewModel pingViewModel)
        {
            var pingCommand = _mapper.Map<PingCommand>(pingViewModel);
            Bus.SendCommand(pingCommand);
            return _sendMessagesService.SendMessageAsync(pingCommand);
        }

    }
}
