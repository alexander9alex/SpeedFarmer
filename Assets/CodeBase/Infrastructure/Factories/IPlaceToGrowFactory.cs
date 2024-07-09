using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Infrastructure.Factories
{
   public interface IPlaceToGrowFactory
   {
      void CreatePlacesToGrow(List<Vector2> markers, Transform parent);
   }
}