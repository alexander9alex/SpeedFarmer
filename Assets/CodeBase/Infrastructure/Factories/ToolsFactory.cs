using System.Collections.Generic;
using System.Linq;
using CodeBase.Data;
using CodeBase.Data.ToolDir;
using CodeBase.Game.Hero;
using CodeBase.Game.InventoryDir;
using CodeBase.Services;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Factories
{
   class ToolsFactory : IToolsFactory
   {
      private readonly ToolsData _toolsData;
      private readonly IHeroHitFinder _heroHitFinder;

      public ToolsFactory(IStaticData staticData, IHeroHitFinder heroHitFinder)
      {
         _heroHitFinder = heroHitFinder;
         _toolsData = staticData.GetToolsData();
      }

      public void CreateTools(List<ToolSpawnPointMarker> markers, Transform parent, HeroAnimator heroAnimator)
      {
         foreach (ToolSpawnPointMarker marker in markers)
            CreateTool(marker, parent, heroAnimator);
      }

      private void CreateTool(ToolSpawnPointMarker marker, Transform parent, HeroAnimator heroAnimator)
      {
         GameObject prefab = _toolsData.ToolPrefabs.First(tool => tool.ToolType == marker.ToolType).Prefab;
         GameObject tool = Object.Instantiate(prefab, marker.Position, Quaternion.identity, parent);
         tool.GetComponent<ITool>().Construct(_heroHitFinder, heroAnimator);
      }
   }
}