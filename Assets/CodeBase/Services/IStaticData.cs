using CodeBase.Data;
using CodeBase.StaticData;

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
   }
}