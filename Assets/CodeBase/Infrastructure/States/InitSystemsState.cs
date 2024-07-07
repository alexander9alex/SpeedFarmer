using CodeBase.Ecs.Systems;
using CodeBase.Infrastructure.Factories;
using Leopotam.Ecs;
using Zenject;

namespace CodeBase.Infrastructure.States
{
   public class InitSystemsState : IState, ITickable
   {
      private readonly IGameStateMachine _gameStateMachine;
      private readonly EcsSystems _systems;
      private readonly IEcsSystemsFactory _systemsFactory;
      private bool _initialized;

      public InitSystemsState(IGameStateMachine gameStateMachine, EcsSystems systems, IEcsSystemsFactory systemsFactory)
      {
         _gameStateMachine = gameStateMachine;
         _systems = systems;
         _systemsFactory = systemsFactory;
      }

      public void Enter()
      {
         InitSystems();
         _systems.Init();
         _initialized = true;
         _gameStateMachine.Enter<LoadProgressState>();
      }

      public void Exit()
      {
      }

      public void Tick()
      {
         if (_initialized)
            _systems.Run();
      }

      private void InitSystems()
      {
         _systems.Add(_systemsFactory.CreateSystem<TryInteractSystem>());
         _systems.Add(_systemsFactory.CreateSystem<DropItemSystem>());
      }
   }
}