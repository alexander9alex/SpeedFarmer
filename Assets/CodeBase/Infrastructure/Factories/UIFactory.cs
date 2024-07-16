using System;
using CodeBase.Data.Menu;
using CodeBase.Game.InventoryDir;
using CodeBase.Game.UI;
using CodeBase.Services;
using CodeBase.StaticData;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CodeBase.Infrastructure.Factories
{
   class UIFactory : IUIFactory
   {
      private readonly IGameStateMachine _gameStateMachine;
      private readonly IStaticData _staticData;
      private readonly IInventory _inventory;

      public UIFactory(IGameStateMachine gameStateMachine, IStaticData staticData, IInventory inventory)
      {
         _gameStateMachine = gameStateMachine;
         _staticData = staticData;
         _inventory = inventory;
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

      public void CreateHud()
      {
         HudData hudData = _staticData.GetHudData();
         GameObject hud = Object.Instantiate(hudData.HudPrefab);

         CreateInventory(hud.transform, hudData.InventoryPrefab);
      }

      private void CreateInventory(Transform parent, GameObject inventoryPrefab)
      {
         GameObject inventory = Object.Instantiate(inventoryPrefab, parent);
         inventory.GetComponent<InventoryView>().Construct(_staticData.GetInventoryData(), _inventory);
      }

      private void CreateMainMenu()
      {
         GameObject mainMenuPrefab = _staticData.GetMenuData().MainMenuPrefab;
         GameObject mainMenu = Object.Instantiate(mainMenuPrefab);
         mainMenu.GetComponent<MainMenu>().Construct(_gameStateMachine);
      }
   }
}