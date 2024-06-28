using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.StaticData
{
   [CreateAssetMenu(menuName = "Static Data/Menu Data", fileName = "MenuData")]
   public class MenuData : ScriptableObject
   {
      [FormerlySerializedAs("MenuDataPrefab")] public GameObject MainMenuPrefab;
   }
}