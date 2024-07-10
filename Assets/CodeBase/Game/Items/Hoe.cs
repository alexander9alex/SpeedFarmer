using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Data.Items.Tools;
using CodeBase.Ecs.Components;
using CodeBase.Game.PlaceToGrowDir;
using CodeBase.Services;
using Leopotam.Ecs;
using UnityEngine;

namespace CodeBase.Game.Items
{
   public class Hoe : ITool
   {
      private const string PlaceToGrowLayerName = "PlaceToGrow";
      private readonly LayerMask _placeToGrowLayerMask;

      private const float Distance = 0.4f;
      private static readonly Vector3 Offset = new(0, -.25f, 0);
      private static readonly Vector3 CollisionBoxSize = new(.4f, .4f, 1);

      public ToolData ToolData { get; }
      public Sprite Icon => ToolData.Icon;

      private readonly EcsWorld _world;
      private readonly IHeroHitFinder _heroHitFinder;
      private readonly IItemView _itemView;

      public Hoe(EcsWorld world, IHeroHitFinder heroHitFinder, ToolData toolData, IItemView itemView)
      {
         _heroHitFinder = heroHitFinder;
         _world = world;
         ToolData = toolData;
         
         _itemView = itemView;
         _itemView.Construct(this);
         
         _placeToGrowLayerMask = 1 << LayerMask.NameToLayer(PlaceToGrowLayerName);
      }

      public void Use()
      {
         EcsEntity entity = _world.NewEntity();
         ref ChangeAnimationRequest changeAnimation = ref entity.Get<ChangeAnimationRequest>();
         changeAnimation.AnimationName = HeroAnimationData.Plowing;
         changeAnimation.WaitState = AnimationWaitState.WaitEnd;
         changeAnimation.OnEnded = OnAnimationEnded;
      }

      public void DestroyView() =>
         _itemView.Destroy();

      private void OnAnimationEnded()
      {
         List<RaycastHit2D> hits = _heroHitFinder.GetHitWithMask(CollisionBoxSize, Distance, Offset, _placeToGrowLayerMask);
         TryPlow(hits);
         Debug.Log("Hoe used!");
      }

      private static void TryPlow(List<RaycastHit2D> hits)
      {
         foreach (RaycastHit2D hit in hits)
         {
            if (hit.collider != null)
            {
               IPlaceToGrow placeToGrow = hit.collider.GetComponent<IPlaceToGrow>();

               if (placeToGrow.CanPlow())
               {
                  placeToGrow.Plow();
                  break;
               }
            }
         }
      }
   }
}