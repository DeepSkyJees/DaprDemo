using Dapr.Actors.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nigel.Dapr.DomainActors.ActorModels;

namespace Nigel.Dapr.DomainActors
{
    public class UserActor:Actor,IUserActor
    {
        public UserActor(ActorHost host) : base(host)
        {
        }

        public async Task<bool> SaveUserAsync(Goods user)
        {
            await this.StateManager.AddStateAsync($"user_{this.Id}", user);
            return true;
        }
 

        public async Task<Goods> GetUserAsync()
        {
           var user =  await this.StateManager.GetStateAsync<Goods>($"user_{this.Id}");
           return user;
        }
    }
}
