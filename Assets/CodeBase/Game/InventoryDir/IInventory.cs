using System;
using CodeBase.Data;
using CodeBase.Game.Items;

namespace CodeBase.Game.InventoryDir
{
   public interface IInventory
   {
      public event Action<IItem> ItemChanged;
      public IItem GetItemData();
      public void SetItem(IItem item);
      public bool HasItem();
      public IItem RemoveItem();
      public void UseItem();
   }
}