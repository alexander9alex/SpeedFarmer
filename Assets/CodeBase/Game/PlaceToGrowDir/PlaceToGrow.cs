using System;
using System.Linq;
using CodeBase.Data.PlaceToGrowDir;
using CodeBase.Services;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Game.PlaceToGrowDir
{
   public class PlaceToGrow : MonoBehaviour, IPlaceToGrow
   {
      [SerializeField] private SpriteRenderer _dirtSr;
      [SerializeField] private SpriteRenderer _plantSr;

      private PlaceToGrowData _placeToGrowData;
      private PlaceToGrowDirt _currentDirtState = PlaceToGrowDirt.Simple;

      public void Construct(IStaticData staticData)
      {
         _placeToGrowData = staticData.GetPlaceToGrowData();
         UpdateDirt();
      }

      public void Plow()
      {
         _currentDirtState = PlaceToGrowDirt.Plowed;
         UpdateDirt();
      }

      public void Plant() { }

      private void UpdateDirt() =>
         _dirtSr.sprite = GetDirtSprite(_currentDirtState);

      private Sprite GetDirtSprite(PlaceToGrowDirt dirtState) =>
         _placeToGrowData.DirtSprites.First(state => state.SpriteType == dirtState).Sprite;
   }
}