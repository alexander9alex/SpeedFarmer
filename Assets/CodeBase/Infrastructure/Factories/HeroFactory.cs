using CodeBase.Game.Hero;
using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.Factories
{
   public class HeroFactory : IHeroFactory
   {
      private readonly IStaticData _staticData;
      private readonly IInputService _inputService;

      public HeroFactory(IStaticData staticData, IInputService inputService)
      {
         _staticData = staticData;
         _inputService = inputService;
      }
      
      public Transform CreateHero()
      {
         GameObject heroPrefab = _staticData.GetHeroData().HeroPrefab;
         GameObject hero = Object.Instantiate(heroPrefab);

         hero.GetComponent<HeroMover>().Construct(_inputService);
         hero.GetComponent<HeroAnimator>().Construct(_inputService);

         return hero.transform;
      }
   }
}