using CodeBase.Game.Items;

namespace CodeBase.Game.PlaceToGrowDir
{
   public interface IPlaceToGrow
   {
      public void Plow();
      public void Plant(ISeed seed);
      public bool CanPlow();
      public bool CanPlant();
   }
}