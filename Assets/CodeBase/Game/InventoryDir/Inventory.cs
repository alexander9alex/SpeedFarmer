using System;

namespace CodeBase.Game.InventoryDir
{
   public class Inventory : IInventory
   {
      public event Action<ITool> ItemChanged;

      private ITool _currentTool;

      public ITool GetItem() => 
         _currentTool;

      public void SetItem(ITool tool)
      {
         _currentTool = tool;
         ItemChanged?.Invoke(_currentTool);
      }

      public ITool DropItem()
      {
         ITool tool = _currentTool;
         _currentTool = null;
         ItemChanged?.Invoke(_currentTool);
         return tool;
      }

      public void UseItem() =>
         _currentTool?.Use();

      public bool HasItem() =>
         _currentTool != null;
   }
}