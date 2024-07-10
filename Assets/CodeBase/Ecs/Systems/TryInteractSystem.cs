using System.Collections.Generic;
using CodeBase.Data.FinderData;
using CodeBase.Ecs.Components;
using CodeBase.Game.InventoryDir;
using CodeBase.Game.Items;
using CodeBase.Services;
using Leopotam.Ecs;
using UnityEngine;

namespace CodeBase.Ecs.Systems
{
   public class TryInteractSystem : IEcsRunSystem
   {
      private EcsFilter<TryInteractRequest> _requests;

      private readonly IInventory _inventory;
      private readonly IHeroHitFinder _heroHitFinder;
      private readonly int _interactableLayerMask;

      public TryInteractSystem(IInventory inventory, IHeroHitFinder heroHitFinder)
      {
         _inventory = inventory;
         _heroHitFinder = heroHitFinder;
         _interactableLayerMask = 1 << LayerMask.NameToLayer(InteractableHitFinderData.InteractableLayerName);
      }

      public void Run()
      {
         foreach (int i in _requests)
         {
            if (TryFindInteractable(out IInteractable interactable))
               TryInteract(interactable);

            _requests.GetEntity(i).Destroy();
         }
      }

      private void TryInteract(IInteractable interactable)
      {
         if (interactable is IItemView itemView && !_inventory.HasItem())
            TakeItem(itemView.Item);
      }

      private void TakeItem(IItem item)
      {
         item.DestroyView();
         _inventory.SetItem(item);
      }

      private bool TryFindInteractable(out IInteractable interactable)
      {
         List<RaycastHit2D> hits = _heroHitFinder.GetHitWithMask(InteractableHitFinderData.CollisionBoxSize,
            InteractableHitFinderData.Distance, InteractableHitFinderData.Offset, _interactableLayerMask);

         foreach (RaycastHit2D hit in hits)
         {
            if (hit.collider != null)
            {
               interactable = hit.collider.GetComponent<IInteractable>();
               return true;
            }
         }

         interactable = null;
         return false;
      }
   }
}