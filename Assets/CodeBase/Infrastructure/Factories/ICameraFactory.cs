using UnityEngine;

namespace CodeBase.Infrastructure.Factories
{
   public interface ICameraFactory
   {
      public void CreateCamera(Transform hero);
   }
}