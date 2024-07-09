using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Data.ToolDir;
using UnityEngine;

namespace CodeBase.Infrastructure.Factories
{
   public interface IToolsFactory
   {
      public void CreateTools(List<ToolSpawnPointMarker> markers, Transform parent);
   }
}