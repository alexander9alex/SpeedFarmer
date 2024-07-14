using System;
using CodeBase.Data;
using CodeBase.Data.PlaceToGrowDir;

namespace CodeBase.Ecs.Components
{
   public struct GrowingPlant
   {
      public PlantState PlantState;
      public float GrowTime;
      public Action OnGrow;
      public float WiltTime;
      public Action OnWilt;
      public float DropOfWaterActivateTime;
      public Action OnDropOfWaterActivate;
      public bool IsDropOfWaterActivate;
   }
}