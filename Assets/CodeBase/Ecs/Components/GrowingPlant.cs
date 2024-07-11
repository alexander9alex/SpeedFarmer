using System;

namespace CodeBase.Ecs.Components
{
   public struct GrowingPlant
   {
      public float GrowTime;
      public Action OnGrow;
   }
}