using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Services
{
   public interface IHeroHitFinder
   {
      public void Construct(GameObject hero);
      public RaycastHit2D GetHitWithMask(Vector2 boxSize, float distance, Vector3 offset, LayerMask layerMask);
      public RaycastHit2D GetHitWithMask(Vector2 boxSize, Dictionary<Vector2, float> distances, Dictionary<Vector2, Vector2> offsets, LayerMask layerMask);
   }
}