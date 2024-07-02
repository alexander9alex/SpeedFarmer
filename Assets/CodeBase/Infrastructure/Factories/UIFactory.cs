using System;
using CodeBase.Data.Menu;
using CodeBase.Game.UI;
using CodeBase.Infrastructure.States;
using CodeBase.Services;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CodeBase.Infrastructure.Factories
{
   class UIFactory : IUIFactory
   {
      private readonly IGameStateMachine _gameStateMachine;
      private readonly IStaticData _staticData;

      public UIFactory(IGameStateMachine gameStateMachine, IStaticData staticData)
      {
         _gameStateMachine = gameStateMachine;
         _staticData = staticData;
      }

      public void CreateMenu(MenuType menuType)
      {
         switch (menuType)
         {
            case MenuType.MainMenu:
               CreateMainMenu();
               break;
            default:
               throw new ArgumentOutOfRangeException(nameof(menuType), menuType, null);
         }
      }

      private void CreateMainMenu()
      {
         GameObject mainMenuPrefab = _staticData.GetMenuData().MainMenuPrefab;
         GameObject mainMenu = Object.Instantiate(mainMenuPrefab);
         
         MainMenuView mainMenuView = mainMenu.GetComponent<MainMenuView>();
         mainMenuView.PlayButton.onClick.AddListener(LoadGame);
         // mainMenuView.SettingsButton.onClick.AddListener(CreateMenu.Settings);
         mainMenuView.ExitButton.onClick.AddListener(QuitGame);
      }

      private void LoadGame() => 
         _gameStateMachine.Enter<LoadGameState>();

      private void QuitGame() => 
         Application.Quit();
   }
}