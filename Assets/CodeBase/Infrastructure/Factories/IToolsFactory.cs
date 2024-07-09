using System.Collections.Generic;
using CodeBase.Data.ToolDir;
using CodeBase.Game.Hero;
using UnityEngine;

namespace CodeBase.Infrastructure.Factories
{
   public interface IToolsFactory
   {
      public void CreateTools(List<ToolSpawnPointMarker> markers, Transform parent, HeroAnimator heroAnimator);
   }
}