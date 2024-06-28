using System;

namespace CodeBase.Services
{
   public interface ISceneLoader
   {
      public void LoadScene(string name, Action onLoaded = null);
   }
}