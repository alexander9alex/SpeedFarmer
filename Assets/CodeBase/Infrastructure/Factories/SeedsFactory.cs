using System.Linq;
using CodeBase.Data.Items.Seeds;
using CodeBase.Game.Items;
using CodeBase.Services;
using CodeBase.StaticData.Items;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CodeBase.Infrastructure.Factories
{
   public class SeedsFactory : ISeedsFactory
   {
      private readonly IHeroHitFinder _heroHitFinder;
      private Transform _parent;
      private readonly SeedPrefabsData _seedPrefabsData;
      private readonly SeedsData _seedsData;

      public SeedsFactory(IStaticData staticData, IHeroHitFinder heroHitFinder)
      {
         _heroHitFinder = heroHitFinder;
         _seedsData = staticData.GetSeedsData();
         _seedPrefabsData = staticData.GetSeedPrefabsData();
      }

      public void SetParent(Transform parent)
      {
         _parent = new GameObject("Seeds").transform;
         _parent.parent = parent;
      }

      public GameObject CreateSeed(SeedType seedType)
      {
         SeedData seedData = _seedsData.Data.First(seed => seed.SeedType == seedType);
         GameObject seed = Object.Instantiate(_seedPrefabsData.Prefabs.First(seed => seed.SeedType == seedType).Prefab, _parent);
         new Seed(_heroHitFinder, seedData, seed.GetComponent<IItemView>());
         return seed;
      }

      public GameObject CreateSeed(SeedType seedType, Vector3 pos)
      {
         GameObject seed = CreateSeed(seedType);
         seed.transform.position = pos;
         return seed;
      }
   }
}