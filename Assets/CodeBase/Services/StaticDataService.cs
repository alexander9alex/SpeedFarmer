using CodeBase.StaticData;
using CodeBase.StaticData.Items;
using UnityEngine;

namespace CodeBase.Services
{
   public class StaticDataService : IStaticData
   {
      private const string MenuDataPath = "StaticData/MenuData";
      private const string HeroDataPath = "StaticData/HeroData";
      private const string CameraDataPath = "StaticData/CameraData";
      private const string HudDataPath = "StaticData/HudData";
      private const string FarmLocationDataPath = "StaticData/FarmLocationData";
      private const string PlaceToGrowDataPath = "StaticData/PlaceToGrowData";
      
      private const string ToolsDataPath = "StaticData/Items/ToolsData";
      private const string ToolPrefabsDataPath = "StaticData/Items/ToolPrefabsData";
      private const string SeedsDataPath = "StaticData/Items/SeedsData";
      private const string SeedPrefabsDataPath = "StaticData/Items/SeedPrefabsData";
      private const string FruitPrefabsDataPath = "StaticData/Items/FruitPrefabsData";
      private const string FruitsDataPath = "StaticData/Items/FruitsData";

      public MenuData GetMenuData() =>
         Resources.Load<MenuData>(MenuDataPath);

      public HeroData GetHeroData() =>
         Resources.Load<HeroData>(HeroDataPath);

      public CameraData GetCameraData() =>
         Resources.Load<CameraData>(CameraDataPath);

      public HudData GetHudData() =>
         Resources.Load<HudData>(HudDataPath);

      public FarmLocationData GetFarmLocationData() =>
         Resources.Load<FarmLocationData>(FarmLocationDataPath);

      public PlaceToGrowData GetPlaceToGrowData() =>
         Resources.Load<PlaceToGrowData>(PlaceToGrowDataPath);

      public ToolsData GetToolsData() =>
         Resources.Load<ToolsData>(ToolsDataPath);

      public ToolPrefabsData GetToolPrefabsData() =>
         Resources.Load<ToolPrefabsData>(ToolPrefabsDataPath);

      public SeedsData GetSeedsData() =>
         Resources.Load<SeedsData>(SeedsDataPath);

      public SeedPrefabsData GetSeedPrefabsData() =>
         Resources.Load<SeedPrefabsData>(SeedPrefabsDataPath);

      public FruitsData GetFruitsData() =>
         Resources.Load<FruitsData>(FruitsDataPath);

      public FruitPrefabsData GetFruitPrefabsData() =>
         Resources.Load<FruitPrefabsData>(FruitPrefabsDataPath);
   }
}