using System.Collections.Generic;
using CodeBase.Game.PlaceToGrowDir;
using CodeBase.Services;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Factories
{
   class PlaceToGrowFactory : IPlaceToGrowFactory
   {
      private readonly PlaceToGrowData _placeToGrowData;
      private readonly IStaticData _staticData;

      public PlaceToGrowFactory(IStaticData staticData)
      {
         _staticData = staticData;
         _placeToGrowData = _staticData.GetPlaceToGrowData();
      }
      
      public void CreatePlacesToGrow(List<Vector2> markers, Transform parent)
      {
         foreach (Vector2 pos in markers)
            CreatePlaceToGrow(parent, pos);

      }

      private void CreatePlaceToGrow(Transform parent, Vector2 pos)
      {
         GameObject placeToGrowGo = Object.Instantiate(_placeToGrowData.PlaceToGrowPrefab, pos, Quaternion.identity, parent);
         placeToGrowGo.GetComponent<PlaceToGrow>().Construct(_staticData);
      }
   }
}