using System.Collections.Generic;
using CodeBase.Data.FinderData;
using CodeBase.Ecs.Components;
using CodeBase.Game.InventoryDir;
using CodeBase.Game.Items;
using CodeBase.Game.WashtubDir;
using CodeBase.Services;
using Leopotam.Ecs;
using UnityEngine;

namespace CodeBase.Ecs.Systems
{
   public class TryInteractWithItemSystem : IEcsRunSystem
   {
      private EcsFilter<TryInteractWithItemRequest> _requests;

      private readonly IInventory _inventory;
      private readonly IHeroHitFinder _heroHitFinder;
      private readonly int _interactableLayerMask;

      public TryInteractWithItemSystem(IInventory inventory, IHeroHitFinder heroHitFinder)
      {
         _inventory = inventory;
         _heroHitFinder = heroHitFinder;
         _interactableLayerMask = 1 << LayerMask.NameToLayer(InteractableHitFinderData.InteractableLayerName);
      }

      public void Run()
      {
         foreach (int i in _requests)
         {
            TryInteractWithItemRequest tryInteractWithItemRequest = _requests.Get1(i);

            if (TryFindInteractWithMe(out IInteractWithMe interactWithMe))
               TryInteractWithItem(interactWithMe);
            else
               tryInteractWithItemRequest.UseItem?.Invoke();
            
            _requests.GetEntity(i).Destroy();
         }
      }

      private void TryInteractWithItem(IInteractWithMe interactWithMe)
      {
         if (!_inventory.HasItem())
            return;
         
         
         if (interactWithMe is Washtub && _inventory.GetItem() is WateringCan wateringCan)
            wateringCan.FillWithWater();
      }

      private bool TryFindInteractWithMe(out IInteractWithMe interactWithMe)
      {
         List<RaycastHit2D> hits = _heroHitFinder.GetHitWithMask(InteractableHitFinderData.CollisionBoxSize,
            InteractableHitFinderData.Distance, InteractableHitFinderData.Offset, _interactableLayerMask);

         foreach (RaycastHit2D hit in hits)
         {
            if (hit.collider == null)
               continue;
            
            interactWithMe = hit.collider.GetComponent<IInteractWithMe>();

            if (interactWithMe == null)
               continue;
            
            return true;
         }

         interactWithMe = null;
         return false;
      }
   }
}