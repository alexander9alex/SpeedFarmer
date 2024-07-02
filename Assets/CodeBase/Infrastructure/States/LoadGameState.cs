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

      public LoadGameState(ISceneLoader sceneLoader, ICurtain curtain, IHeroFactory heroFactory, ICameraFactory cameraFactory)
      {
         _sceneLoader = sceneLoader;
         _curtain = curtain;
         _heroFactory = heroFactory;
         _cameraFactory = cameraFactory;
      }

      public void Enter() => 
         _curtain.Show(() => _sceneLoader.LoadScene(GameSceneName, OnLoaded));

      private void OnLoaded()
      {
         InitWorld();
         _curtain.Hide();
      }

      private void InitWorld()
      {
         Transform hero = _heroFactory.CreateHero();
         _cameraFactory.CreateCamera(hero);
      }

      public void Exit()
      {
      }
   }
}