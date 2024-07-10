using CodeBase.Data.Items;
using CodeBase.Data.Items.Tools;

namespace CodeBase.Game.Items
{
   public interface ITool : IItem
   {
      public ToolData ToolData { get; }
   }
}