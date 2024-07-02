using CodeBase.StaticData;

namespace CodeBase.Infrastructure.Factories
{
   public interface IStaticData
   {
      public MenuData GetMenuData();
      public HeroData GetHeroData();
      public CameraData GetCameraData();
   }
}