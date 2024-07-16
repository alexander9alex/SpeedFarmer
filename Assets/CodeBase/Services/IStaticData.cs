using CodeBase.StaticData;
using CodeBase.StaticData.Items;

namespace CodeBase.Services
{
   public interface IStaticData
   {
      public MenuData GetMenuData();
      public HeroData GetHeroData();
      public CameraData GetCameraData();
      public HudData GetHudData();
      FarmLocationData GetFarmLocationData();
      public ToolsData GetToolsData();
      PlaceToGrowData GetPlaceToGrowData();
      ToolPrefabsData GetToolPrefabsData();
      SeedPrefabsData GetSeedPrefabsData();
      SeedsData GetSeedsData();
      FruitPrefabsData GetFruitPrefabsData();
      FruitsData GetFruitsData();
      InventoryData GetInventoryData();
   }
}