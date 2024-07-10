using System;
using CodeBase.Data.Items.Tools;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.Data.Items.Seeds
{
   [Serializable]
   public class SeedPrefab
   {
      [FormerlySerializedAs("ToolType")]
      public SeedType SeedType;
      public GameObject Prefab;
   }
}