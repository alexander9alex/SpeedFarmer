using System;
using CodeBase.Game.Items;

namespace CodeBase.Game.InventoryDir
{
   public interface IInventory
   {
      public event Action<IItem> ItemChanged;
      public event Action<DropsOfWater> DropsOfWaterChanged;
      public IItem GetItem();
      public void SetItem(IItem item);
      public bool HasItem();
      public IItem RemoveItem();
      public void UseItem();
   }
}