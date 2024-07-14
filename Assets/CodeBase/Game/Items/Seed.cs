using System.Collections.Generic;
using CodeBase.Data.FinderData;
using CodeBase.Data.Items.Seeds;
using CodeBase.Game.PlaceToGrowDir;
using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Game.Items
{
   public class Seed : ISeed
   {
      public SeedData SeedData { get; }
      public Sprite Icon => SeedData.Icon;

      private readonly IHeroHitFinder _heroHitFinder;
      private readonly IItemView _itemView;
      private readonly LayerMask _placeToGrowLayerMask;

      public Seed(IHeroHitFinder heroHitFinder, SeedData seedData, IItemView itemView)
      {
         _heroHitFinder = heroHitFinder;
         SeedData = seedData;
         _itemView = itemView;
         _itemView.Construct(this);

         _placeToGrowLayerMask = 1 << LayerMask.NameToLayer(ItemHitFinderData.PlaceToGrowLayerName);
      }

      public void Use()
      {
         List<RaycastHit2D> hits = _heroHitFinder.GetHitWithMask(ItemHitFinderData.CollisionBoxSize, ItemHitFinderData.Distance,
            ItemHitFinderData.Offset, _placeToGrowLayerMask);

         foreach (RaycastHit2D hit in hits)
         {
            if (hit.collider != null)
            {
               IPlaceToGrow placeToGrow = hit.collider.GetComponent<IPlaceToGrow>();
               if (placeToGrow.CanPlant())
               {
                  placeToGrow.Plant(this);
                  return;
               }
            }
         }
      }

      public void DestroyView() =>
         _itemView.Destroy();
   }
}