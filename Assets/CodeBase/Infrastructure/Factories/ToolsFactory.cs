using System;
using System.Collections.Generic;
using System.Linq;
using CodeBase.Data.Items.Tools;
using CodeBase.Game.Items;
using CodeBase.Services;
using CodeBase.StaticData.Items;
using Leopotam.Ecs;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CodeBase.Infrastructure.Factories
{
   public class ToolsFactory : IToolsFactory
   {
      private readonly IHeroHitFinder _heroHitFinder;
      private readonly EcsWorld _world;
      private readonly ToolsData _toolsData;
      private readonly ToolPrefabsData _toolPrefabsData;

      private Transform _parent;

      public ToolsFactory(IStaticData staticData, IHeroHitFinder heroHitFinder, EcsWorld world)
      {
         _heroHitFinder = heroHitFinder;
         _world = world;
         _toolsData = staticData.GetToolsData();
         _toolPrefabsData = staticData.GetToolPrefabsData();
      }

      public void SetParent(Transform parent)
      {
         _parent = new GameObject("Tools").transform;
         _parent.parent = parent;
      }

      public void CreateTools(List<ToolSpawnPointMarker> markers)
      {
         foreach (ToolSpawnPointMarker marker in markers)
            CreateTool(marker);
      }

      private void CreateTool(ToolSpawnPointMarker marker)
      {
         GameObject tool = CreateTool(marker.ToolType);
         tool.transform.position = marker.Position;
      }

      public GameObject CreateTool(ToolType toolType, Vector3 pos)
      {
         GameObject item = CreateTool(toolType);
         item.transform.position = pos;
         return item;
      }

      public GameObject CreateTool(ToolType toolType)
      {
         ToolData toolData = _toolsData.Data.First(tool => tool.ToolType == toolType);
         GameObject toolGo = Object.Instantiate(_toolPrefabsData.Prefabs.First(tool => tool.ToolType == toolType).Prefab, _parent);

         switch (toolType)
         {
            case ToolType.Hoe:
               return CreateHoe(toolData, toolGo);
            case ToolType.Axe:
               return CreateAxe(toolData, toolGo);
            case ToolType.WateringCan:
               return CreateWateringCan(toolData, toolGo);
            default:
               throw new ArgumentOutOfRangeException(nameof(toolType), toolType, null);
         }
      }

      private GameObject CreateHoe(ToolData toolData, GameObject go)
      {
         new Hoe(_world, _heroHitFinder, toolData, go.GetComponent<IItemView>());
         return go;
      }

      private GameObject CreateAxe(ToolData toolData, GameObject go)
      {
         new Axe(_world, _heroHitFinder, toolData, go.GetComponent<IItemView>());
         return go;
      }

      private GameObject CreateWateringCan(ToolData toolData, GameObject go)
      {
         new WateringCan(_world, _heroHitFinder, toolData, go.GetComponent<IItemView>());
         return go;
      }
   }
}