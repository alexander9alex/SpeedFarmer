using CodeBase.Data.Menu;
using CodeBase.Infrastructure.Factories;
using CodeBase.Services;

namespace CodeBase.Infrastructure.States
{
   public class LoadMainMenuState : IState
   {
      private const string MainMenuSceneName = "MainMenu";
      
      private readonly ISceneLoader _sceneLoader;
      private readonly ICurtain _curtain;
      private readonly IUIFactory _uiFactory;

      public LoadMainMenuState(ISceneLoader sceneLoader, ICurtain curtain, IUIFactory uiFactory)
      {
         _sceneLoader = sceneLoader;
         _curtain = curtain;
         _uiFactory = uiFactory;
      }

      public void Enter() =>
         _curtain.Show(() => _sceneLoader.LoadScene(MainMenuSceneName, OnLoaded));

      private void OnLoaded()
      {
         InitMenu();
         _curtain.Hide();
      }

      private void InitMenu()
      {
         _uiFactory.CreateMenu(MenusType.MainMenu);
      }
      
      public void Exit()
      {
         
      }
   }
}