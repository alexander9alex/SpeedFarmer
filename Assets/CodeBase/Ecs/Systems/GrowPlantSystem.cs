using CodeBase.Ecs.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace CodeBase.Ecs.Systems
{
   public class GrowPlantSystem : IEcsRunSystem
   {
      private EcsFilter<GrowingPlant> _plants;

      public void Run()
      {
         foreach (int entityId in _plants)
            Grow(entityId);
      }

      private void Grow(int entityId)
      {
         ref GrowingPlant growingPlant = ref _plants.Get1(entityId);
         growingPlant.GrowTime -= Time.deltaTime;
         if (growingPlant.GrowTime <= 0)
         {
            growingPlant.OnGrow?.Invoke();
            _plants.GetEntity(entityId).Destroy();
         }
      }
   }
}