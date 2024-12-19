using Microsoft.AspNetCore.SignalR;
using MultiShop.SignalRRealTimeApi.Services.SignalRCommentServices;
using MultiShop.SignalRRealTimeApi.Services.SignalRMessageServices;

namespace MultiShop.SignalRRealTimeApi.Hubs
{
    public class SignalRHub:Hub
    {
        //private readonly ISignalRMessageService _signalRMessageService;
        private readonly ISignalRCommentService _signalRCommentService;

        public SignalRHub(/*ISignalRMessageService signalRMessageService,*/ ISignalRCommentService signalRCommentService)
        {
            //_signalRMessageService = signalRMessageService;
            _signalRCommentService = signalRCommentService;
        }

        public async Task SendStatisticsCount(string id)
        {
            var getTotalCommentCount = _signalRCommentService.GetTotalCommentCount();
            await Clients.All.SendAsync("ReceiveCommentCount", getTotalCommentCount);

            //var getTotalMessageCount = _signalRMessageService.GetTotalMessageCountByReceiverId(id);
            //await Clients.All.SendAsync("ReceiveMessageCount", getTotalMessageCount);
        }
    }
}
