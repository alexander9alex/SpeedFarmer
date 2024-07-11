using CodeBase.Data.Items.Seeds;
using UnityEngine;

namespace CodeBase.Infrastructure.Factories
{
   public interface IFruitsFactory
   {
      public void SetParent(Transform parent);
      public GameObject CreateFruit(SeedType seedType, Vector3 pos);
   }
}