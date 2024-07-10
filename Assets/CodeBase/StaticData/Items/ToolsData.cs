using System.Collections.Generic;
using CodeBase.Data.Items.Tools;
using UnityEngine;

namespace CodeBase.StaticData.Items
{
   [CreateAssetMenu(menuName = "Static Data/Tools Data", fileName = "ToolsData")]
   public class ToolsData : ScriptableObject
   {
      public List<ToolData> Data;
   }
}