using CodeBase.Game.Hero;

namespace CodeBase.Infrastructure.Factories
{
   public interface ILocationFactory
   {
      public void CreateFarmLocation(HeroAnimator heroAnimator);
   }
}