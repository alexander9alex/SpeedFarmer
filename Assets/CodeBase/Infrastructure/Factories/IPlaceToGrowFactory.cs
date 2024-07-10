using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Infrastructure.Factories
{
   public interface IPlaceToGrowFactory
   {
      public void SetParent(Transform parent);
      public void CreatePlacesToGrow(List<Vector2> markers);
   }
}