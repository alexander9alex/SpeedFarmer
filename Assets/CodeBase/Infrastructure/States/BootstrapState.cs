using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
   public class BootstrapState : IState
   {
      private const string BootSceneName = "Boot";

      private readonly IGameStateMachine _gameStateMachine;
      private readonly ISceneLoader _sceneLoader;

      public BootstrapState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader)
      {
         _gameStateMachine = gameStateMachine;
         _sceneLoader = sceneLoader;
      }

      public void Enter()
      {
         Application.targetFrameRate = 60;

         _sceneLoader.LoadScene(BootSceneName, OnLoaded);
      }

      private void OnLoaded() =>
         _gameStateMachine.Enter<InitEcsState>();

      public void Exit()
      {
      }
   }
}