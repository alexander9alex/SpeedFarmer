using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Data.Items.Tools;
using CodeBase.Ecs.Components;
using CodeBase.Services;
using Leopotam.Ecs;
using UnityEngine;

namespace CodeBase.Game.Items
{
   public abstract class Tool : ITool
   {
      private const float Distance = 0.4f;
      private static readonly Vector3 Offset = new(0, -.25f, 0);
      private static readonly Vector3 CollisionBoxSize = new(.4f, .4f, 1);

      public ToolData ToolData { get; }
      public Sprite Icon => ToolData.Icon;

      private readonly EcsWorld _world;
      private readonly IHeroHitFinder _heroHitFinder;
      private readonly IItemView _itemView;

      protected Tool(EcsWorld world, IHeroHitFinder heroHitFinder, ToolData toolData, IItemView itemView)
      {
         _heroHitFinder = heroHitFinder;
         _world = world;
         ToolData = toolData;

         _itemView = itemView;
         _itemView.Construct(this);
      }

      public void Use()
      {
         EcsEntity entity = _world.NewEntity();
         ref ChangeAnimationRequest changeAnimation = ref entity.Get<ChangeAnimationRequest>();
         changeAnimation.AnimationName = GetAnimationActionName();
         changeAnimation.WaitState = AnimationWaitState.WaitEnd;
         changeAnimation.OnActionCompleted = OnActionCompleted;
      }

      public void DestroyView() =>
         _itemView.Destroy();

      private void OnActionCompleted()
      {
         List<RaycastHit2D> hits = _heroHitFinder.GetHitWithMask(CollisionBoxSize, Distance, Offset, GetLayerMask());
         TryDoAction(hits);
         Debug.Log("Tool used!");
      }

      private void TryDoAction(List<RaycastHit2D> hits)
      {
         foreach (RaycastHit2D hit in hits)
         {
            if (TryDoAction(hit))
               break;
         }
      }

      protected abstract bool TryDoAction(RaycastHit2D hit);
      protected abstract LayerMask GetLayerMask();
      protected abstract string GetAnimationActionName();
   }
}