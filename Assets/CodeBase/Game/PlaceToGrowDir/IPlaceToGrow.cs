using CodeBase.Game.Items;

namespace CodeBase.Game.PlaceToGrowDir
{
   public interface IPlaceToGrow
   {
      public bool CanPlow();
      public void Plow();
      public bool CanPlant();
      public void Plant(ISeed seed);
      public bool CanChop();
      public void Chop();
      bool CanPour();
      void Pour();
   }
}