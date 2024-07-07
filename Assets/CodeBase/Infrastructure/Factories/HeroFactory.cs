using CodeBase.Ecs.Components;
using CodeBase.Game.Hero;
using CodeBase.Services;
using Leopotam.Ecs;
using UnityEngine;

namespace CodeBase.Infrastructure.Factories
{
   public class HeroFactory : IHeroFactory
   {
      private readonly IStaticData _staticData;
      private readonly IInputService _inputService;
      private readonly EcsWorld _world;

      public HeroFactory(IStaticData staticData, IInputService inputService, EcsWorld world)
      {
         _staticData = staticData;
         _inputService = inputService;
         _world = world;
      }
      
      public Transform CreateHero()
      {
         GameObject heroPrefab = _staticData.GetHeroData().HeroPrefab;
         GameObject hero = Object.Instantiate(heroPrefab);

         hero.GetComponent<HeroMover>().Construct(_inputService);
         hero.GetComponent<HeroAnimator>().Construct(_inputService);

         EcsEntity heroEntity = _world.NewEntity();
         ref Hero heroComponent = ref heroEntity.Get<Hero>();
         heroComponent.HeroGo = hero;
         
         return hero.transform;
      }
   }
}