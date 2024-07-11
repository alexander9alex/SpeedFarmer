using CodeBase.Data.Items;

namespace CodeBase.Game.Items
{
   public interface IFruit : IItem
   {
      public FruitData FruitData { get; }
   }
}