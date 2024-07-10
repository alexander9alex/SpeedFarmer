using UnityEngine;

namespace CodeBase.Data.FinderData
{
   public static class ItemHitFinderData
   {
      public const float Distance = 0.4f;
      public const string PlaceToGrowLayerName = "PlaceToGrow";
      public static readonly Vector3 CollisionBoxSize = new(.4f, .4f, 1);
      public static readonly Vector3 Offset = new(0, -.25f, 0);
   }
}