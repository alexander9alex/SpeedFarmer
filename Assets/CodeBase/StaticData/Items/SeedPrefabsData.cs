using System.Collections.Generic;
using CodeBase.Data.Items.Seeds;
using UnityEngine;

namespace CodeBase.StaticData.Items
{
   [CreateAssetMenu(menuName = "Static Data/Items/Seed Prefabs Data", fileName = "SeedPrefabsData")]
   public class SeedPrefabsData : ScriptableObject
   {
      public List<SeedPrefab> Prefabs;
   }
}