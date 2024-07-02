using UnityEngine;

namespace CodeBase.StaticData
{
   [CreateAssetMenu(menuName = "Static Data/Camera Data", fileName = "CameraData")]
   public class CameraData : ScriptableObject
   {
      public GameObject CameraPrefab;
   }
}