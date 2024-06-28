using System;
using CodeBase.Data.Menu;
using CodeBase.Game.UI;
using CodeBase.Infrastructure.States;
using CodeBase.StaticData;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace CodeBase.Infrastructure.Factories
{
   class UIFactory : IUIFactory, IInitializable
   {
      private const string MenuDataPath = "StaticData/MenuData";
      
      private readonly IGameStateMachine _gameStateMachine;
      
      private MenuData _menus;

      public UIFactory(IGameStateMachine gameStateMachine)
      {
         _gameStateMachine = gameStateMachine;
      }

      public void Initialize()
      {
         _menus = Resources.Load<MenuData>(MenuDataPath);
      }

      public void CreateMenu(MenusType menuType)
      {
         switch (menuType)
         {
            case MenusType.MainMenu:
               CreateMainMenu();
               break;
            default:
               throw new ArgumentOutOfRangeException(nameof(menuType), menuType, null);
         }
      }

      private void CreateMainMenu()
      {
         GameObject mainMenu = Object.Instantiate(_menus.MainMenuPrefab);
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