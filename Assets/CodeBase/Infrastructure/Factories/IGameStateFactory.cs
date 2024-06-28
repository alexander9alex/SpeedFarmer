using CodeBase.Infrastructure.States;

namespace CodeBase.Infrastructure.Factories
{
   public interface IGameStateFactory
   {
      public TState CreateState<TState>() where TState : class, IExitableState;
   }
}