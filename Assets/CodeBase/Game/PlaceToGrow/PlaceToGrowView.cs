using UnityEngine;

namespace CodeBase.Game.PlaceToGrow
{
   public class PlaceToGrowView : MonoBehaviour, IPlaceToGrow
   {
      [SerializeField] private SpriteRenderer _dirtSr;
      [SerializeField] private SpriteRenderer _plantSr;

      private PlaceToGrow _placeToGrow;

      public void Construct(PlaceToGrow placeToGrow)
      {
         _placeToGrow = placeToGrow;
         _placeToGrow.DirtChanged += OnDirtChanged;
         _placeToGrow.PlantChanged += OnPlantChanged;
      }

      private void OnDirtChanged(Sprite sprite) =>
         _dirtSr.sprite = sprite;

      private void OnPlantChanged(Sprite sprite) =>
         _plantSr.sprite = sprite;

      public void Plow() =>
         _placeToGrow.Plow();

      public void Plant() =>
         _placeToGrow.Plant();
   }
}