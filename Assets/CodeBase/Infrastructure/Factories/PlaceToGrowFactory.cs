using System.Collections.Generic;
using CodeBase.Game.InventoryDir;
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
      private Transform _parent;
      private readonly IInventory _inventory;

      public PlaceToGrowFactory(IStaticData staticData, IInventory inventory)
      {
         _staticData = staticData;
         _inventory = inventory;
         _placeToGrowData = _staticData.GetPlaceToGrowData();
      }

      public void SetParent(Transform parent)
      {
         _parent = new GameObject("PlacesToGrow").transform;
         _parent.parent = parent;
      }

      public void CreatePlacesToGrow(List<Vector2> markers)
      {
         foreach (Vector2 pos in markers)
            CreatePlaceToGrow(pos);

      }

      private void CreatePlaceToGrow(Vector2 pos)
      {
         GameObject placeToGrowGo = Object.Instantiate(_placeToGrowData.PlaceToGrowPrefab, pos, Quaternion.identity, _parent);
         placeToGrowGo.GetComponent<PlaceToGrow>().Construct(_inventory, _staticData);
      }
   }
}