using System;
using CodeBase.Data;
using CodeBase.Game.Items;

namespace CodeBase.Game.InventoryDir
{
   public class Inventory : IInventory
   {
      public event Action<IItem> ItemChanged;

      private IItem _currentItem;

      public IItem GetItemData() => 
         _currentItem;

      public void SetItem(IItem item)
      {
         _currentItem = item;
         ItemChanged?.Invoke(_currentItem);
      }

      public IItem RemoveItem()
      {
         IItem item = _currentItem;
         _currentItem = null;
         ItemChanged?.Invoke(_currentItem);
         return item;
      }

      public void UseItem() =>
         _currentItem?.Use();

      public bool HasItem() =>
         _currentItem != null;
   }
}