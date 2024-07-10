using CodeBase.Game.InventoryDir;

namespace CodeBase.Game.Items
{
   public interface IItemView : IInteractable
   {
      public IItem Item { get; }
      public void Construct(IItem item);
      public void Destroy();
   }
}