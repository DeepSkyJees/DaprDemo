using Dapr.Actors.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nigel.Dapr.BackendApi.Dtos;
using Nigel.Dapr.DomainActors;

namespace Nigel.Dapr.BackendApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IActorProxy actorProxy;
        public UserController(IActorProxy actorProxy)
        {
            this.actorProxy = actorProxy;
        }
        //[HttpPost("Create")]
        //[ProducesResponseType(200, Type = typeof(bool))]
        //public Task<ActionResult> CreateUserAsync(CreateUser createUser)
        //{
        //    actorProxy.Create<IUserActor>();
        //}
    }
}
