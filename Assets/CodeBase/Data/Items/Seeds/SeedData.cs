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
      public Sprite GrownSprite;
      public GameObject FruitPrefab;

      [Header("Balance data")]
      public float GrowTime = 15;
   }
}