using System;
using CodeBase.Game.Items;

namespace CodeBase.Game.InventoryDir
{
   public class Inventory : IInventory
   {
      public event Action<IItem> ItemChanged;
      public event Action<DropsOfWater> DropsOfWaterChanged;

      private IItem _currentItem;

      public IItem GetItemData() => 
         _currentItem;

      public void SetItem(IItem item)
      {
         _currentItem = item;
         ItemChanged?.Invoke(_currentItem);

         if (item is WateringCan wateringCan)
            wateringCan.DropsOfWaterChanged += DropsOfWaterChanged;
      }

      public IItem RemoveItem()
      {
         IItem item = _currentItem;
         _currentItem = null;
         ItemChanged?.Invoke(null);
         
         if (item is WateringCan wateringCan)
            wateringCan.DropsOfWaterChanged -= DropsOfWaterChanged;
         
         return item;
      }

      public void UseItem() =>
         _currentItem?.Use();

      public bool HasItem() =>
         _currentItem != null;
   }
}