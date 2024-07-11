using System.Collections.Generic;
using CodeBase.Data.Items;
using UnityEngine;

namespace CodeBase.StaticData.Items
{
   [CreateAssetMenu(menuName = "Static Data/Items/Fruits Data", fileName = "FruitsData", order = 0)]
   public class FruitsData : ScriptableObject
   {
      public List<FruitData> Data;
   }
}