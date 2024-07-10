using CodeBase.Data.Items.Seeds;
using UnityEngine;

namespace CodeBase.Infrastructure.Factories
{
   public interface ISeedsFactory
   {
      public void SetParent(Transform parent);
      public GameObject CreateSeed(SeedType seedType);
      public GameObject CreateSeed(SeedType seedType, Vector3 pos);
   }
}