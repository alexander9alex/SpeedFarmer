using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Factories
{
   public class StaticDataService : IStaticData
   {
      private const string MenuDataPath = "StaticData/MenuData";
      private const string HeroDataPath = "StaticData/HeroData";
      private const string CameraDataPath = "StaticData/CameraData";

      public MenuData GetMenuData() => 
         Resources.Load<MenuData>(MenuDataPath);

      public HeroData GetHeroData() => 
         Resources.Load<HeroData>(HeroDataPath);

      public CameraData GetCameraData() => 
         Resources.Load<CameraData>(CameraDataPath);
   }
}