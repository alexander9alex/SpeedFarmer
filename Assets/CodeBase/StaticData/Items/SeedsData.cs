using System.Collections.Generic;
using CodeBase.Data.Items.Seeds;
using UnityEngine;

namespace CodeBase.StaticData.Items
{
   [CreateAssetMenu(menuName = "Static Data/Seeds Data", fileName = "SeedsData")]
   public class SeedsData : ScriptableObject
   {
      public List<SeedData> Data;
   }
}