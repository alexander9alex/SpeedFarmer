using UnityEngine;

namespace CodeBase.Data.FinderData
{
   public static class InteractableHitFinderData
   {
      public const float Distance = 0.4f;
      public const string InteractableLayerName = "Interactable";
      public static readonly Vector3 CollisionBoxSize = new(.65f, .8f, 1);
      public static readonly Vector3 Offset = new(0, -.1f, 0);
   }
}