using Leopotam.Ecs;

namespace CodeBase.Infrastructure.States
{
   public class InitEcsState : IState
   {
      private readonly IGameStateMachine _gameStateMachine;
      private readonly EcsSystems _ecsSystems;

      public InitEcsState(IGameStateMachine gameStateMachine, EcsSystems ecsSystems)
      {
         _gameStateMachine = gameStateMachine;
         _ecsSystems = ecsSystems;
      }

      public void Enter()
      {
         _ecsSystems.Init();
         _gameStateMachine.Enter<LoadProgressState>();
      }

      public void Exit()
      {
      }
   }
}