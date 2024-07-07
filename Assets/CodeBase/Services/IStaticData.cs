using CodeBase.StaticData;

namespace CodeBase.Services
{
   public interface IStaticData
   {
      public MenuData GetMenuData();
      public HeroData GetHeroData();
      public CameraData GetCameraData();
      public HudData GetHudData();
   }
}