using System;

namespace CodeBase.Services
{
   public interface ICurtain
   {
      public void Show(Action onShowed = null);
      public void Hide(Action onHided = null);
   }
}