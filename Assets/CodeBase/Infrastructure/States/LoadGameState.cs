using CodeBase.Infrastructure.Factories;
using CodeBase.Services;

namespace CodeBase.Infrastructure.States
{
   public class LoadGameState : IState
   {
      private const string GameSceneName = "Game";
      
      private readonly ISceneLoader _sceneLoader;
      private readonly ICurtain _curtain;
      private readonly IHeroFactory _heroFactory;

      public LoadGameState(ISceneLoader sceneLoader, ICurtain curtain, IHeroFactory heroFactory)
      {
         _sceneLoader = sceneLoader;
         _curtain = curtain;
         _heroFactory = heroFactory;
      }

      public void Enter() => 
         _curtain.Show(() => _sceneLoader.LoadScene(GameSceneName, OnLoaded));

      private void OnLoaded()
      {
         _heroFactory.CreateHero();
         _curtain.Hide();
      }

      public void Exit()
      {
      }
   }
}