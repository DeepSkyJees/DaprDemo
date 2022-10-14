using Dapr.Actors;
using Nigel.Dapr.DomainActors.ActorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nigel.Dapr.DomainActors
{
    public interface IGoodsActor : IActor
    {
        Task<Goods> GetGoodsAsync();

        Task<bool> DeductGoodsAsync(int count);
    }
}
