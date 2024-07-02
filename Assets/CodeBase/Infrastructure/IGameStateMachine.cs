using CodeBase.Infrastructure.States;

namespace CodeBase.Infrastructure
{
   public interface IGameStateMachine
   {
      public void Enter<TState>() where TState : class, IState;
   }
}