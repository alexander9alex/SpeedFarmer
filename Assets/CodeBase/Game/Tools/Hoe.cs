using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Game.Hero;
using CodeBase.Game.InventoryDir;
using CodeBase.Game.PlaceToGrowDir;
using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Game.Tools
{
   public class Hoe : MonoBehaviour, ITool
   {
      private const string PlaceToGrowLayerName = "PlaceToGrow";
      private LayerMask _placeToGrowLayerMask;

      private readonly Dictionary<Vector2, float> Distances = new()
      {
         {Vector2.right, 0.65f},
         {Vector2.left, 0.65f},
         {Vector2.down, 0.65f},
         {Vector2.up, -0.35f},
      };

      private readonly Dictionary<Vector2, Vector2> Offsets = new()
      {
         {Vector2.right, new(0, -0.55f)},
         {Vector2.left, new(0, -0.55f)},
         {Vector2.down, new(-0.2f, 0)},
         {Vector2.up, new(0.2f, 0)},
      };

      private static readonly Vector3 CollisionBoxSize = new(.05f, .05f, 1);
      
      public Sprite Icon => _icon;
      [SerializeField] private Sprite _icon;
      
      private IHeroHitFinder _heroHitFinder;
      private HeroAnimator _heroAnimator;

      public void Construct(IHeroHitFinder heroHitFinder, HeroAnimator heroAnimator)
      {
         _heroHitFinder = heroHitFinder;
         _heroAnimator = heroAnimator;
         _placeToGrowLayerMask = 1 << LayerMask.NameToLayer(PlaceToGrowLayerName);
      }

      public void Use() =>
         _heroAnimator.ChangeAnimation(HeroAnimationData.Plowing, AnimationWaitState.WaitEnd, OnAnimationEnded);

      private void OnAnimationEnded()
      {
         RaycastHit2D hit = _heroHitFinder.GetHitWithMask(CollisionBoxSize, Distances, Offsets, _placeToGrowLayerMask);
         if (hit.collider != null)
            hit.collider.GetComponent<IPlaceToGrow>().Plow();
         
         Debug.Log("Hoe used!");
      }

      public GameObject InstantiateView(Vector3 pos)
      {
         transform.position = pos; 
         gameObject.SetActive(true);
         return gameObject;
      }

      public void DestroyView() =>
         gameObject.SetActive(false);
   }
}