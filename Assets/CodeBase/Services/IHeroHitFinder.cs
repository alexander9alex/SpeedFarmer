using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.Services
{
   public interface IHeroHitFinder
   {
      public void Construct(GameObject hero);
      public List<RaycastHit2D> GetHitWithMask(Vector2 boxSize, float distance, Vector3 offset, LayerMask layerMask);
   }
}