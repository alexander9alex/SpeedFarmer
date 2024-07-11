using System.Collections.Generic;
using CodeBase.Data.Items.Seeds;
using UnityEngine;

namespace CodeBase.StaticData.Items
{
   [CreateAssetMenu(menuName = "Static Data/Items/Fruit Prefabs Data", fileName = "FruitPrefabsData")]
   public class FruitPrefabsData : ScriptableObject
   {
      public List<FruitPrefab> Prefabs;
   }
}