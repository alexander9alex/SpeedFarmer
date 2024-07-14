using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Data.Items.Tools;
using CodeBase.Game.PlaceToGrowDir;
using CodeBase.Services;
using Leopotam.Ecs;
using UnityEngine;

namespace CodeBase.Game.Items
{
   public class WateringCan : Tool
   {
      private const string PlaceToGrowLayerName = "PlaceToGrow";
      private readonly int _placeToGrowLayerMask;

      private const float TopDownDistance = 0.5f;
      private readonly Vector2 _topDownOffset = new(0, -.3f);
      private readonly Vector2 _topDownCollisionBoxSize = new(.4f, .4f);

      private const float LeftRightDistance = 1.1f;
      private readonly Vector2 _leftRightOffset = new(0, -.25f);
      private readonly Vector2 _rightLeftCollisionBoxSize = new(.8f, .4f);

      public WateringCan(EcsWorld world, IHeroHitFinder heroHitFinder, ToolData toolData, IItemView itemView) : base(world, heroHitFinder,
         toolData, itemView) =>
         _placeToGrowLayerMask = 1 << LayerMask.NameToLayer(PlaceToGrowLayerName);

      protected override bool TryDoAction(RaycastHit2D hit)
      {
         // in any case remove water count

         IPlaceToGrow placeToGrow = hit.collider.GetComponent<IPlaceToGrow>();

         if (placeToGrow.CanPour())
         {
            placeToGrow.Pour();
            return true;
         }

         return false;
      }

      protected override List<RaycastHit2D> GetHitWithMask()
      {
         Vector2 heroLookDir = _heroHitFinder.GetHeroLookDir();

         if (heroLookDir.y != 0)
            return _heroHitFinder.GetHitWithMask(_topDownCollisionBoxSize, TopDownDistance, _topDownOffset, GetLayerMask());
         
         return _heroHitFinder.GetHitWithMask(_rightLeftCollisionBoxSize, LeftRightDistance, _leftRightOffset, GetLayerMask());
      }

      protected override LayerMask GetLayerMask() =>
         _placeToGrowLayerMask;

      protected override string GetAnimationActionName() =>
         HeroAnimationData.Pour;
   }
}