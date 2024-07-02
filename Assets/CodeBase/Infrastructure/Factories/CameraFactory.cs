using CodeBase.Game.Camera;
using UnityEngine;

namespace CodeBase.Infrastructure.Factories
{
   public class CameraFactory : ICameraFactory
   {
      private readonly IStaticData _staticData;

      public CameraFactory(IStaticData staticData)
      {
         _staticData = staticData;
      }
      
      public void CreateCamera(Transform hero)
      {
         GameObject cameraPrefab = _staticData.GetCameraData().CameraPrefab;
         GameObject camera = Object.Instantiate(cameraPrefab);
         
         camera.GetComponent<CameraFollower>().Construct(hero);
      }
   }
}