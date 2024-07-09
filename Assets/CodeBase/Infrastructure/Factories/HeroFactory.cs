using CodeBase.Ecs.Components;
using CodeBase.Game.Hero;
using CodeBase.Services;
using CodeBase.StaticData;
using Leopotam.Ecs;
using UnityEngine;

namespace CodeBase.Infrastructure.Factories
{
   public class HeroFactory : IHeroFactory
   {
      private readonly IInputService _inputService;
      private readonly EcsWorld _world;
      private readonly HeroData _heroData;
      private readonly IHeroHitFinder _heroHitFinder;

      public HeroFactory(IStaticData staticData, IInputService inputService, EcsWorld world, IHeroHitFinder heroHitFinder)
      {
         _inputService = inputService;
         _world = world;
         _heroHitFinder = heroHitFinder;
         _heroData = staticData.GetHeroData();
      }
      
      public Transform CreateHero()
      {
         GameObject hero = Object.Instantiate(_heroData.HeroPrefab);

         _heroHitFinder.Construct(hero);
         HeroAnimator heroAnimator = hero.GetComponent<HeroAnimator>();
         heroAnimator.Construct(_inputService);
         hero.GetComponent<HeroMover>().Construct(_inputService, heroAnimator);

         EcsEntity heroEntity = _world.NewEntity();
         ref Hero heroComponent = ref heroEntity.Get<Hero>();
         heroComponent.HeroGo = hero;
         
         return hero.transform;
      }
   }
}