using Dapr.Actors;
using Dapr.Actors.Runtime;
using Nigel.Dapr.DomainActors.ActorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nigel.Dapr.DomainActors
{
    public class GoodsActor : Actor, IGoodsActor
    {
        public GoodsActor(ActorHost host) : base(host)
        {
        }
        public async Task<Goods> GetGoodsAsync()
        {
            var goods = new Goods
            {
                Name = "DaprBook",
                Count = 10000
            };
            goods = await this.StateManager.GetOrAddStateAsync("goods_store", goods);
            return goods;

        }

        public async Task<bool> DeductGoodsAsync(int count)
        {
            var goods = new Goods
            {
                Name = "DaprBook",
                Count = 10
            };
            goods = await this.StateManager.GetOrAddStateAsync("goods_store", goods);

            if (goods.Count <= 0)
            {
                //throw new Exception("商品已售罄");
                Console.WriteLine("商品已售罄");
                return false;
            }

            if (goods.Count < count)
            {
                Console.WriteLine("商品数量不足");
                //throw new Exception("商品数量不足");
                return false;
            }

            goods.Count = goods.Count - count;
            Console.WriteLine($"扣减数量:{count}成功，剩余：{goods.Count}");
            await this.StateManager.SetStateAsync("goods_store", goods);
            return true;
        }
    }

}




