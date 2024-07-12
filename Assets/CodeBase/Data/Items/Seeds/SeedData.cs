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

      [Header("Balance data")]
      public float GrowTime = 15;
   }
}