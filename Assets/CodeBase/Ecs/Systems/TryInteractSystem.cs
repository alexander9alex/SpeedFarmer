using CodeBase.Data;
using CodeBase.Ecs.Components;
using CodeBase.Game.Hero;
using CodeBase.Game.InventoryDir;
using CodeBase.HelpTools;
using Leopotam.Ecs;
using UnityEngine;

namespace CodeBase.Ecs.Systems
{
   public class TryInteractSystem : IEcsRunSystem
   {
      private const string InteractableLayerName = "Interactable";
      private readonly int _interactableLayerMask;

      private EcsFilter<TryInteractRequest> _requests;
      private EcsFilter<Hero> _heroes;

      private readonly Vector3 _collisionBoxSize = new(.65f, .8f, 1);
      private readonly float _distance = 0.4f;
      private readonly Vector3 _offsetToLegs = new(0, -.1f, 0);
      private readonly IInventory _inventory;

      public TryInteractSystem(IInventory inventory)
      {
         _inventory = inventory;
         _interactableLayerMask = 1 << LayerMask.NameToLayer(InteractableLayerName);
      }

      public void Run()
      {
         foreach (int i in _requests)
         {
            foreach (int j in _heroes)
            {
               GameObject hero = _heroes.Get1(j).HeroGo;

               if (TryFindInteractable(hero, out IInteractable interactable))
                  TryInteract(interactable);
            }

            _requests.GetEntity(i).Destroy();
         }
      }

      private void TryInteract(IInteractable interactable)
      {
         if (interactable is IItem item && !_inventory.HasItem())
            TakeItem(item);
      }

      private void TakeItem(IItem item)
      {
         item.DestroyView();
         _inventory.SetItem(item);
      }

      private bool TryFindInteractable(GameObject hero, out IInteractable interactable)
      {
         RaycastHit2D hit = GetHitWithInteractable(hero);
         if (hit.collider != null)
         {
            interactable = hit.collider.GetComponent<IInteractable>();
            return true;
         }

         interactable = null;
         return false;
      }

      private RaycastHit2D GetHitWithInteractable(GameObject hero)
      {
         Vector2 lookDir = hero.GetComponent<HeroMover>().GetLookDir();

         RaycastHit2D[] hits = new RaycastHit2D[1];
         Vector3 heroPos = hero.transform.position + _offsetToLegs;

         PhysicsDebug.DrawBox(heroPos + new Vector3(lookDir.x, lookDir.y) * _distance, _collisionBoxSize / 2, 5);
         Physics2D.BoxCastNonAlloc(heroPos, _collisionBoxSize, 0, lookDir, hits, _distance, _interactableLayerMask);
         return hits[0];
      }
   }
}