using System.Collections.Generic;
using CodeBase.Data.Items.Tools;
using UnityEngine;

namespace CodeBase.StaticData.Items
{
   [CreateAssetMenu(menuName = "Static Data/Tools Prefabs Data", fileName = "ToolPrefabsData")]
   public class ToolPrefabsData : ScriptableObject
   {
      public List<ToolPrefab> Prefabs;
   }
}