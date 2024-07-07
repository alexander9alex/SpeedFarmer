using System;
using CodeBase.Data.Menu;
using CodeBase.Game.InventoryDir;
using CodeBase.Game.UI;
using CodeBase.Services;
using CodeBase.StaticData;
using Leopotam.Ecs;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CodeBase.Infrastructure.Factories
{
   class UIFactory : IUIFactory
   {
      private readonly IGameStateMachine _gameStateMachine;
      private readonly IStaticData _staticData;
      private readonly IInventory _inventory;
      private readonly IInputService _inputService;
      private readonly EcsWorld _world;

      public UIFactory(IGameStateMachine gameStateMachine, IStaticData staticData, IInventory inventory, IInputService inputService, EcsWorld world)
      {
         _gameStateMachine = gameStateMachine;
         _staticData = staticData;
         _inventory = inventory;
         _inputService = inputService;
         _world = world;
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
         inventory.GetComponent<InventoryView>().Construct(_inventory);
      }

      private void CreateMainMenu()
      {
         GameObject mainMenuPrefab = _staticData.GetMenuData().MainMenuPrefab;
         GameObject mainMenu = Object.Instantiate(mainMenuPrefab);
         mainMenu.GetComponent<MainMenuView>().Construct(_gameStateMachine);
      }
   }
}