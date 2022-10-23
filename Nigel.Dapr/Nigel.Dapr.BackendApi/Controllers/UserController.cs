using Dapr;
using Dapr.Actors.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Nigel.Dapr.BackendApi.Dtos;
using Nigel.Dapr.DomainActors;

namespace Nigel.Dapr.BackendApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    { 
        [HttpPost("receiveUserMessage")]
        [Topic("pubsub", "receiveUserMessage")]
        [ProducesResponseType(200, Type = typeof(bool))]
        public async Task<ActionResult> ReceiveUserMessageAsync([FromBody]  string receiveMessage)
        {
            Console.WriteLine($"接收到消息:{receiveMessage}");
            return this.Ok(await Task.FromResult($"接收到消息:{receiveMessage}"));
        }

        //[HttpPost("myevent")]
        //[ProducesResponseType(200, Type = typeof(bool))]
        //public async Task<ActionResult> DaprEventAsync([FromBody] string eventMessage)
        //{
        //    Console.WriteLine($"接收到消息:{eventMessage}");
        //    return this.Ok(await Task.FromResult($"接收到消息:{eventMessage}"));
        //}
    }
}
