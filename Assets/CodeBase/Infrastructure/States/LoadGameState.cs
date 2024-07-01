using CodeBase.Services;

namespace CodeBase.Infrastructure.States
{
   public class LoadGameState : IState
   {
      private const string GameSceneName = "Game";
      
      private readonly ISceneLoader _sceneLoader;
      private readonly ICurtain _curtain;

      public LoadGameState(ISceneLoader sceneLoader, ICurtain curtain)
      {
         _sceneLoader = sceneLoader;
         _curtain = curtain;
      }

      public void Enter()
      {
         _curtain.Show(() => _sceneLoader.LoadScene(GameSceneName, OnLoaded));
      }

      private void OnLoaded()
      {
         _curtain.Hide();
      }

      public void Exit()
      {
      }
   }
}