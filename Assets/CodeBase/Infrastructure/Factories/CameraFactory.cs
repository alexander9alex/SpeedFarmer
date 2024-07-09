using CodeBase.Game.Camera;
using CodeBase.Services;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Factories
{
   public class CameraFactory : ICameraFactory
   {
      private readonly CameraData _cameraData;

      public CameraFactory(IStaticData staticData)
      {
         _cameraData = staticData.GetCameraData();
      }
      
      public void CreateCamera(Transform hero)
      {
         GameObject camera = Object.Instantiate(_cameraData.CameraPrefab);
         
         camera.GetComponent<CameraFollower>().Construct(hero);
      }
   }
}