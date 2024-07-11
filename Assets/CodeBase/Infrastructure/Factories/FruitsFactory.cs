using System.Linq;
using CodeBase.Data.Items;
using CodeBase.Data.Items.Seeds;
using CodeBase.Game.Items;
using CodeBase.Services;
using CodeBase.StaticData.Items;
using UnityEngine;

namespace CodeBase.Infrastructure.Factories
{
   public class FruitsFactory : IFruitsFactory
   {
      private readonly FruitPrefabsData _fruitPrefabsData;
      private readonly FruitsData _fruitsData;

      private Transform _parent;

      public FruitsFactory(IStaticData staticData)
      {
         _fruitsData = staticData.GetFruitsData();
         _fruitPrefabsData = staticData.GetFruitPrefabsData();
      }

      public void SetParent(Transform parent)
      {
         _parent = new GameObject("Fruits").transform;
         _parent.parent = parent;
      }

      public GameObject CreateFruit(SeedType seedType, Vector3 pos)
      {
         FruitData fruitData = _fruitsData.Data.First(fruit => fruit.SeedType == seedType);
         GameObject prefab = _fruitPrefabsData.Prefabs.First(fruit => fruit.SeedType == seedType).Prefab;
         GameObject fruitGo = Object.Instantiate(prefab, pos, Quaternion.identity, _parent);
         new Fruit(fruitGo.GetComponent<IItemView>(), fruitData);
         return fruitGo;
      }
   }
}