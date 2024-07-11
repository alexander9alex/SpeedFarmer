using CodeBase.Data;
using CodeBase.Data.Items.Tools;
using CodeBase.Game.PlaceToGrowDir;
using CodeBase.Services;
using Leopotam.Ecs;
using UnityEngine;

namespace CodeBase.Game.Items
{
   public class Axe : Tool
   {
      private const string PlaceToGrowLayerName = "PlaceToGrow";
      private readonly int _placeToGrowLayerMask;

      public Axe(EcsWorld world, IHeroHitFinder heroHitFinder, ToolData toolData, IItemView itemView) : base(world, heroHitFinder, toolData, itemView) =>
         _placeToGrowLayerMask = 1 << LayerMask.NameToLayer(PlaceToGrowLayerName);
      
      protected override bool TryDoAction(RaycastHit2D hit)
      {
         if (hit.collider != null)
         {
            IPlaceToGrow placeToGrow = hit.collider.GetComponent<IPlaceToGrow>();

            if (placeToGrow.CanChop())
            {
               placeToGrow.Chop();
               return true;
            }
         }

         return false;
      }

      protected override LayerMask GetLayerMask() =>
         _placeToGrowLayerMask;
      protected override string GetAnimationActionName() =>
         HeroAnimationData.Chop;
   }
}