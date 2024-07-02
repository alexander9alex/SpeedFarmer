using CodeBase.StaticData;

namespace CodeBase.Infrastructure.Factories
{
   public interface IStaticData
   {
      MenuData GetMenuData();
      HeroData GetHeroData();
   }
}