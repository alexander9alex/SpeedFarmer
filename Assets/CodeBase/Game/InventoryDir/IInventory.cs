using System;

namespace CodeBase.Game.InventoryDir
{
   public interface IInventory
   {
      public ITool GetItem();
      public void SetItem(ITool tool);
      public bool HasItem();
      public ITool DropItem();
      public void UseItem();
      public event Action<ITool> ItemChanged;
   }
}