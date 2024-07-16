using CodeBase.Game.InventoryDir;
using CodeBase.Game.Items;
using UnityEngine;

namespace CodeBase.Game.WashtubDir
{
   public class Washtub : MonoBehaviour, IInteractWithMe
   {
      private IInventory _inventory;
      public void Construct(IInventory inventory)
      {
         _inventory = inventory;
      }

      public void Interact()
      {
         if (_inventory.GetItem() is WateringCan washtub)
            washtub.FillWithWater();
      }
   }
}