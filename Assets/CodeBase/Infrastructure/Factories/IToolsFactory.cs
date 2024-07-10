using System.Collections.Generic;
using CodeBase.Data.Items.Tools;
using UnityEngine;

namespace CodeBase.Infrastructure.Factories
{
   public interface IToolsFactory
   {
      public void SetParent(Transform parent);
      public void CreateTools(List<ToolSpawnPointMarker> markers);
      public GameObject CreateTool(ToolType toolType);
      public GameObject CreateTool(ToolType toolType, Vector3 pos);
   }
}