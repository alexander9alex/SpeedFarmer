using System;
using CodeBase.Data;

namespace CodeBase.Ecs.Components
{
   public struct GrowingPlant
   {
      public float GrowTime;
      public PlantState PlantState;
      public Action OnGrow;
   }
}