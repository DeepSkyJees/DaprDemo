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
            Parallel.ForEach(Enumerable.Range(1, 10), async i =>
            {
                while (true)
                {
                    var goods = await goodsActor.GetGoodsAsync();
                    Console.WriteLine($"[Worker-{i}] Count for account '{goods.Name}' is '{goods.Count}'.");

                    Console.WriteLine($"[Worker-{i}] buy '{1m:c}'...");
                    try
                    {
                        await goodsActor.DeductGoodsAsync(i);
                    }
                    catch (ActorMethodInvocationException ex)
                    {
                        Console.WriteLine("[Worker-{i}] Overdraft: " + ex.Message);
                    }

                    Task.Delay(1000).Wait();
                }
            });
            return this.Ok(await goodsActor.GetGoodsAsync());
        }
    }
}
