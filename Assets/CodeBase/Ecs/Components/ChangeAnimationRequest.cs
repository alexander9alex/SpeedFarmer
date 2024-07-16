using System;
using CodeBase.Data;

namespace CodeBase.Ecs.Components
{
   public struct ChangeAnimationRequest
   {
      public string AnimationName;
      public AnimationWaitState WaitState;
      public Action OnActionCompleted;
   }
}