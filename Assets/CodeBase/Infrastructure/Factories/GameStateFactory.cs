using CodeBase.Infrastructure.States;
using Zenject;

namespace CodeBase.Infrastructure.Factories
{
   public class GameStateFactory : IGameStateFactory
   {
      private readonly DiContainer _diContainer;

      public GameStateFactory(DiContainer diContainer) =>
         _diContainer = diContainer;

      public TState CreateState<TState>() where TState : class, IExitableState =>
         _diContainer.Resolve<TState>();
   }
}