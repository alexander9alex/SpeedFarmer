using CodeBase.Data;
using CodeBase.Ecs.Components;
using CodeBase.Game.Hero;
using CodeBase.Game.Items;
using CodeBase.Infrastructure.Factories;
using Leopotam.Ecs;
using UnityEngine;

namespace CodeBase.Ecs.Systems
{
   public class ChopPlantSystem : IEcsRunSystem
   {
      private const float Force = 8f;

      private EcsFilter<ChopPlant> _plants;
      private EcsFilter<Hero> _heroes;

      private readonly IFruitsFactory _fruitsFactory;

      public ChopPlantSystem(IFruitsFactory fruitsFactory) =>
         _fruitsFactory = fruitsFactory;

      public void Run()
      {
         foreach (int i in _plants)
         {
            foreach (int j in _heroes)
            {
               ChopPlant chopPlant = _plants.Get1(i);
               GameObject hero = _heroes.Get1(j).HeroGo;
               Chop(chopPlant, hero);
            }

            _plants.GetEntity(i).Destroy();
         }
      }

      private void Chop(ChopPlant chopPlant, GameObject hero)
      {
         if (chopPlant.PlantState != PlantState.Grown)
            return;

         Vector2 lookDir = hero.GetComponent<HeroMover>().GetLookDir();
         GameObject fruit = _fruitsFactory.CreateFruit(chopPlant.SeedType, chopPlant.Position);

         fruit.AddComponent<SmoothShowing>().StartShowing();
         fruit.GetComponent<Rigidbody2D>().AddForce(lookDir * Force + lookDir * hero.GetComponent<Rigidbody2D>().velocity.magnitude,
            ForceMode2D.Impulse);
      }
   }
}