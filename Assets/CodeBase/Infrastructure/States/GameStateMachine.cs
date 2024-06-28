using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.Factories;
using Zenject;

namespace CodeBase.Infrastructure.States
{
   public class GameStateMachine : IGameStateMachine, IInitializable
   {
      private readonly IGameStateFactory _gameStateFactory;

      private Dictionary<Type, IExitableState> _states;
      private IExitableState _currentState;

      public GameStateMachine(IGameStateFactory gameStateFactory) =>
         _gameStateFactory = gameStateFactory;

      public void Initialize()
      {
         _states = new()
         {
            { typeof(BootstrapState), _gameStateFactory.CreateState<BootstrapState>() },
            { typeof(InitEcsState), _gameStateFactory.CreateState<InitEcsState>() },
            { typeof(LoadProgressState), _gameStateFactory.CreateState<LoadProgressState>() },
            { typeof(LoadMainMenuState), _gameStateFactory.CreateState<LoadMainMenuState>() },
            { typeof(LoadGameState), _gameStateFactory.CreateState<LoadGameState>() },
         };

         Enter<BootstrapState>();
      }
      
      public void Enter<TState>() where TState : class, IState
      {
         _currentState?.Exit();
         TState state = GetState<TState>();
         state.Enter();
         _currentState = state;
      }

      private TState GetState<TState>() where TState : class, IExitableState =>
         _states[typeof(TState)] as TState;
   }
}