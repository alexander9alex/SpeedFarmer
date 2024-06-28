using CodeBase.Services;

namespace CodeBase.Infrastructure.States
{
   public class LoadGameState : IState
   {
      private const string GameSceneName = "Game";
      private readonly ISceneLoader _sceneLoader;

      public LoadGameState(ISceneLoader sceneLoader)
      {
         _sceneLoader = sceneLoader;
      }

      public void Enter()
      {
         _sceneLoader.LoadScene(GameSceneName);
      }

      public void Exit()
      {
      }
   }
}