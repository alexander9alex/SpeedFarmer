using CodeBase.Infrastructure.Factories;
using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
   public class LoadGameState : IState
   {
      private const string GameSceneName = "Game";

      private readonly ISceneLoader _sceneLoader;
      private readonly ICurtain _curtain;
      private readonly IHeroFactory _heroFactory;
      private readonly ICameraFactory _cameraFactory;
      private readonly IUIFactory _uiFactory;
      private readonly IGameStateMachine _gameStateMachine;
      private readonly ILocationFactory _locationFactory;

      public LoadGameState(ISceneLoader sceneLoader, ICurtain curtain, IHeroFactory heroFactory,
         ICameraFactory cameraFactory, IUIFactory uiFactory, IGameStateMachine gameStateMachine, ILocationFactory locationFactory)
      {
         _sceneLoader = sceneLoader;
         _curtain = curtain;
         _heroFactory = heroFactory;
         _cameraFactory = cameraFactory;
         _uiFactory = uiFactory;
         _gameStateMachine = gameStateMachine;
         _locationFactory = locationFactory;
      }

      public void Enter() =>
         _curtain.Show(() => _sceneLoader.LoadScene(GameSceneName, OnLoaded));

      private void OnLoaded()
      {
         Cursor.visible = false;
         InitWorld();
         _curtain.Hide();

         _gameStateMachine.Enter<GameLoopState>();
      }

      private void InitWorld()
      {
         Transform hero = _heroFactory.CreateHero();
         _cameraFactory.CreateCamera(hero);
         _uiFactory.CreateHud();
         _locationFactory.CreateFarmLocation();
      }

      public void Exit() { }
   }
}