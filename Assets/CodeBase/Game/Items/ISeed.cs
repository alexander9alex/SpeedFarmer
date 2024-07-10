using CodeBase.Data.Items.Seeds;

namespace CodeBase.Game.Items
{
   public interface ISeed : IItem
   {
      public SeedData SeedData { get; }
   }
}