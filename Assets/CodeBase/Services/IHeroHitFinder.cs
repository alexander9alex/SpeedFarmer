using UnityEngine;

namespace CodeBase.Services
{
   public interface IHeroHitFinder
   {
      public void Construct(GameObject hero);
      public RaycastHit2D GetHitWithMask(Vector2 boxSize, float distance, LayerMask layerMask);
   }
}