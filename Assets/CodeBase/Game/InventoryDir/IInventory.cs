using System;

namespace CodeBase.Game.InventoryDir
{
   public interface IInventory
   {
      public IItem GetItem();
      public void SetItem(IItem item);
      public bool HasItem();
      public IItem DropItem();
      public void UseItem();
      public event Action<IItem> ItemChanged;
   }
}