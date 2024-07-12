using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Data.Items.Seeds
{
   [Serializable]
   public class SeedData
   {
      public SeedType SeedType;
      public Sprite Icon;
      public List<Sprite> GrowSprites;
      public List<int> GrowOrderInLayer;
      public Sprite GrownSprite;
      public Sprite WiltedSprite;

      [Header("Balance data")]
      public float GrowTime = 10;
      public float WiltTime = 15;
   }
}