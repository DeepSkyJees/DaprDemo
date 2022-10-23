using Dapr.Actors.Client;
using Dapr.Actors;
using Microsoft.AspNetCore.Mvc;
using Nigel.Dapr.DomainActors;

namespace Nigel.Dapr.BackendApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SeckillController : ControllerBase
    {
        [HttpPost("SellDaprBook")]
        public async Task<ActionResult> SellDaprBookAsync(string daprActorId, int sellCount)
        {
            var goodsActor = ActorProxy.Create<IGoodsActor>(new ActorId(daprActorId), "GoodsActor");
            var goods = await goodsActor.DeductGoodsAsync(sellCount);
            return this.Ok(goods);
        }

        [HttpPost("GetDaprBook")]
        public async Task<ActionResult> GetDaprBookAsync(string daprActorId)
        {
            var goodsActor = ActorProxy.Create<IGoodsActor>(new ActorId(daprActorId), "GoodsActor");
            var goods = await goodsActor.GetGoodsAsync();
            return this.Ok(goods);
        }
    }
}
