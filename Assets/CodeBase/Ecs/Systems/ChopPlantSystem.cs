using CodeBase.Data;
using CodeBase.Ecs.Components;
using CodeBase.Infrastructure.Factories;
using Leopotam.Ecs;
using UnityEngine;

namespace CodeBase.Ecs.Systems
{
   public class ChopPlantSystem : IEcsRunSystem
   {
      private EcsFilter<ChopPlant> _plants;
      
      private readonly IFruitsFactory _fruitsFactory;
      public ChopPlantSystem(IFruitsFactory fruitsFactory) =>
         _fruitsFactory = fruitsFactory;

      public void Run()
      {
         foreach (int i in _plants)
         {
            ChopPlant chopPlant = _plants.Get1(i);
            Chop(chopPlant);
            _plants.GetEntity(i).Destroy();
         }
      }

      private void Chop(ChopPlant chopPlant)
      {
         if (chopPlant.PlantState != PlantState.Grown)
            return;

         GameObject fruit = _fruitsFactory.CreateFruit(chopPlant.SeedType, chopPlant.Position);
         // fruit.GetComponent<>()
      }
   }
}