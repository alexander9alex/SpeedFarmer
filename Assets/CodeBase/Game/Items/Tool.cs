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
      private readonly Vector3 _offset = new(0, -.25f, 0);
      private readonly Vector3 _collisionBoxSize = new(.4f, .4f, 1);

      public ToolData ToolData { get; }
      public Sprite Icon => ToolData.Icon;

      protected readonly IHeroHitFinder _heroHitFinder;
      private readonly EcsWorld _world;
      private IItemView _itemView;

      protected Tool(EcsWorld world, IHeroHitFinder heroHitFinder, ToolData toolData)
      {
         _heroHitFinder = heroHitFinder;
         _world = world;
         ToolData = toolData;
      }

      public void Use()
      {
         EcsEntity entity = _world.NewEntity();
         ref ChangeAnimationRequest changeAnimation = ref entity.Get<ChangeAnimationRequest>();
         changeAnimation.AnimationName = GetAnimationActionName();
         changeAnimation.WaitState = AnimationWaitState.WaitEnd;
         changeAnimation.CanUseItem = CanUseItem;
         changeAnimation.OnActionCompleted = OnActionCompleted;
      }

      public void SetView(IItemView itemView)
      {
         itemView.Construct(this);
         _itemView = itemView;
      }

      public void DestroyView() =>
         _itemView.Destroy();

      private void OnActionCompleted()
      {
         List<RaycastHit2D> hits = GetHitWithMask();
         TryDoAction(hits);
         Debug.Log("Tool used!");
      }

      protected virtual List<RaycastHit2D> GetHitWithMask() =>
         _heroHitFinder.GetHitWithMask(_collisionBoxSize, Distance, _offset, GetLayerMask());

      protected virtual void TryDoAction(List<RaycastHit2D> hits)
      {
         foreach (RaycastHit2D hit in hits)
         {
            if (TryDoAction(hit))
               break;
         }
      }

      protected abstract bool CanUseItem();
      protected abstract bool TryDoAction(RaycastHit2D hit);
      protected abstract LayerMask GetLayerMask();
      protected abstract string GetAnimationActionName();
   }
}