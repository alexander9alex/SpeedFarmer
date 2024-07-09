using CodeBase.Data;
using CodeBase.Ecs.Components;
using CodeBase.Game.InventoryDir;
using CodeBase.Services;
using Leopotam.Ecs;
using UnityEngine;

namespace CodeBase.Ecs.Systems
{
   public class TryInteractSystem : IEcsRunSystem
   {
      private const string InteractableLayerName = "Interactable";
      private readonly int _interactableLayerMask;
      private const float Distance = 0.4f;
      private static readonly Vector3 CollisionBoxSize = new(.65f, .8f, 1);
      
      private EcsFilter<TryInteractRequest> _requests;

      private readonly IInventory _inventory;
      private readonly IHeroHitFinder _heroHitFinder;

      public TryInteractSystem(IInventory inventory, IHeroHitFinder heroHitFinder)
      {
         _inventory = inventory;
         _heroHitFinder = heroHitFinder;
         _interactableLayerMask = 1 << LayerMask.NameToLayer(InteractableLayerName);
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
         if (interactable is ITool item && !_inventory.HasItem())
            TakeItem(item);
      }

      private void TakeItem(ITool tool)
      {
         tool.DestroyView();
         _inventory.SetItem(tool);
      }

      private bool TryFindInteractable(out IInteractable interactable)
      {
         RaycastHit2D hit = _heroHitFinder.GetHitWithMask(CollisionBoxSize, Distance, _interactableLayerMask);
         if (hit.collider != null)
         {
            interactable = hit.collider.GetComponent<IInteractable>();
            return true;
         }

         interactable = null;
         return false;
      }
   }
}