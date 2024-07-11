using CodeBase.Data;
using CodeBase.Data.Items.Seeds;
using UnityEngine;

namespace CodeBase.Ecs.Components
{
   public struct ChopPlant
   {
      public PlantState PlantState;
      public Vector3 Position;
      public SeedType SeedType;
   }
}