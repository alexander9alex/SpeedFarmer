using CodeBase.Ecs.Components;
using CodeBase.Game.InventoryDir;
using CodeBase.Game.Items;
using Leopotam.Ecs;

namespace CodeBase.Services
{
   public class Interactor : IInteractor
   {
      private readonly IInventory _inventory;
      private readonly EcsWorld _world;

      public Interactor(IInputService inputService, IInventory inventory, EcsWorld world)
      {
         _inventory = inventory;
         _world = world;
         inputService.Interact += OnInteract;
         inputService.Drop += OnDrop;
      }
      
      private void OnInteract()
      {
         if (_inventory.HasItem())
            _inventory.UseItem();
         else
            TryInteract();
      }

      private void OnDrop()
      {
         if (_inventory.HasItem())
            DropItem();
      }

      private void TryInteract()
      {
         EcsEntity entity = _world.NewEntity();
         entity.Get<TryInteractRequest>();
      }

      private void DropItem()
      {
         IItem item = _inventory.DropItem();
         
         EcsEntity entity = _world.NewEntity();
         ref DropItemRequest dropItemRequest = ref entity.Get<DropItemRequest>();
         dropItemRequest.ItemData = item;
      }
   }
}