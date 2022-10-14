using Dapr.Actors;
using Nigel.Dapr.DomainActors.ActorModels;

namespace Nigel.Dapr.DomainActors
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Dapr.Actors.IActor" />
    public interface IUserActor:IActor
    {
        /// <summary>
        /// Saves the user asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        Task<bool> SaveUserAsync(Goods user);

        /// <summary>
        /// Gets the user asynchronous.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        Task<Goods> GetUserAsync();
    }
}