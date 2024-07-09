using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Data.ToolDir;
using UnityEngine;

namespace CodeBase.StaticData
{
   [CreateAssetMenu(menuName = "Static Data/Tools Data", fileName = "ToolsData")]
   public class ToolsData : ScriptableObject
   {
      public List<ToolPrefab> ToolPrefabs;
   }
}