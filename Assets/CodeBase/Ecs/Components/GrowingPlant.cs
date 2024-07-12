using System;
using CodeBase.Data;

namespace CodeBase.Ecs.Components
{
   public struct GrowingPlant
   {
      public PlantState PlantState;
      public float GrowTime;
      public Action OnGrow;
      public float WiltTime;
      public Action OnWilt;
   }
}