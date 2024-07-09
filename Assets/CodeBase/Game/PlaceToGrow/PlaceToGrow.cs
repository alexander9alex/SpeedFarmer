using System;
using System.Linq;
using CodeBase.Data.PlaceToGrowDir;
using CodeBase.Services;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Game.PlaceToGrow
{
   public class PlaceToGrow
   {
      private readonly PlaceToGrowData _placeToGrowData;
      
      public event Action<Sprite> DirtChanged;
      public event Action<Sprite> PlantChanged;

      private PlaceToGrowDirt _dirtState = PlaceToGrowDirt.Simple;
      
      public PlaceToGrow(IStaticData staticData) =>
         _placeToGrowData = staticData.GetPlaceToGrowData();

      public void Init() =>
         DirtChanged?.Invoke(GetDirtSprite(_dirtState));

      public void Plow()
      {
         _dirtState = PlaceToGrowDirt.Plowed;
         DirtChanged?.Invoke(GetDirtSprite(_dirtState));
      }

      public void Plant()
      {
         
      }

      private Sprite GetDirtSprite(PlaceToGrowDirt dirtState) =>
         _placeToGrowData.DirtSprites.First(state => state.SpriteType == dirtState).Sprite;
   }
}