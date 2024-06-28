namespace CodeBase.Infrastructure.States
{
   public class LoadProgressState : IState
   {
      private readonly IGameStateMachine _gameStateMachine;

      public LoadProgressState(IGameStateMachine gameStateMachine)
      {
         _gameStateMachine = gameStateMachine;
      }

      public void Enter()
      {
         _gameStateMachine.Enter<LoadMainMenuState>();
      }

      public void Exit()
      {
      }
   }
}