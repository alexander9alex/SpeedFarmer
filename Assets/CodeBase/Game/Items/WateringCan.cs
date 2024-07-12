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

      protected override LayerMask GetLayerMask() =>
         _placeToGrowLayerMask;

      protected override string GetAnimationActionName() =>
         HeroAnimationData.Pour;
   }
}