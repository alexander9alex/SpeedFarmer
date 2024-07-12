using System.Collections.Generic;
using System.Linq;
using CodeBase.Game.Hero;
using CodeBase.HelpTools;
using UnityEngine;

namespace CodeBase.Services
{
   public class HeroHitFinder : IHeroHitFinder
   {
      private const float ColliderVisibleTime = 15;
      private const float BoxDistanceZ = 100;
      private GameObject _hero;

      public void Construct(GameObject hero) =>
         _hero = hero;

      public List<RaycastHit2D> GetHitWithMask(Vector2 boxSize, float distance, Vector3 offset, LayerMask layerMask)
      {
         if (_hero == null)
            return default;

         Vector2 lookDir = _hero.GetComponent<HeroMover>().GetLookDir();

         RaycastHit2D[] hits = new RaycastHit2D[10];
         Vector3 boxCenter = _hero.transform.position + offset + new Vector3(lookDir.x, lookDir.y) * distance;

         PhysicsDebug.DrawBox(boxCenter, boxSize / 2, ColliderVisibleTime);
         Physics2D.BoxCastNonAlloc(boxCenter, boxSize, 0, Vector2.zero, hits, BoxDistanceZ, layerMask);
         
         return hits.Where(hit => hit.collider != null).OrderBy(hit => Vector3.Distance(_hero.transform.position, hit.transform.position)).ToList();
      }
   }
}