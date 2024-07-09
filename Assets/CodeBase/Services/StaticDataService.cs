using CodeBase.Data;
using CodeBase.StaticData;
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
      private const string ToolsDataPath = "StaticData/ToolsData";
      private const string PlaceToGrowDataPath = "StaticData/PlaceToGrowData";

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

      public ToolsData GetToolsData() =>
         Resources.Load<ToolsData>(ToolsDataPath);

      public PlaceToGrowData GetPlaceToGrowData() =>
         Resources.Load<PlaceToGrowData>(PlaceToGrowDataPath);

   }
}