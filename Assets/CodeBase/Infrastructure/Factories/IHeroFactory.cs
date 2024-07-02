using UnityEngine;

namespace CodeBase.Infrastructure.Factories
{
   public interface IHeroFactory
   {
      public Transform CreateHero();
   }
}