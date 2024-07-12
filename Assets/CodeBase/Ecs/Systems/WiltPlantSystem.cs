using CodeBase.Data;
using CodeBase.Ecs.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace CodeBase.Ecs.Systems
{
   public class WiltPlantSystem : IEcsRunSystem
   {
      private EcsFilter<GrowingPlant> _plants;

      public void Run()
      {
         foreach (int entityId in _plants)
            Wilt(entityId);
      }

      private void Wilt(int entityId)
      {
         ref GrowingPlant growingPlant = ref _plants.Get1(entityId);
         growingPlant.WiltTime -= Time.deltaTime;
         if (growingPlant.PlantState == PlantState.Growing && growingPlant.WiltTime <= 0)
            growingPlant.OnWilt?.Invoke();
      }
   }
}