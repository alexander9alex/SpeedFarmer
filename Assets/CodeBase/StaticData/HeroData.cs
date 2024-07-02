using UnityEngine;

namespace CodeBase.StaticData
{
   [CreateAssetMenu(menuName = "Static Data/Hero Data", fileName = "HeroData")]
   public class HeroData : ScriptableObject
   {
      public GameObject HeroPrefab;
   }
}