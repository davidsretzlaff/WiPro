using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WiPro.Domain.EntityDto;
using WiPro.Service.Interface;

namespace WiPro.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueWaitingController : ControllerBase
    {
        private readonly IQueueWaitingService _queueWaitingService;
        public QueueWaitingController(IQueueWaitingService queueWaitingService)
        {
            _queueWaitingService = queueWaitingService;
        }
        
        [HttpPost("AddItemFila")]
        public string AddItemFila([FromBody] List<CoinDto> listCoins)
        {
            return _queueWaitingService.AddItens(listCoins);
        }

        [HttpGet("GetItemFila")]
        public string GetItemFila()
        {
            return _queueWaitingService.GetList();
        }
    }
}