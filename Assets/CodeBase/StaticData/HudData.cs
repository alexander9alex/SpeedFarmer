using UnityEngine;

namespace CodeBase.StaticData
{
   [CreateAssetMenu(menuName = "Static Data/Hud Data", fileName = "HudData")]
   public class HudData : ScriptableObject
   {
      public GameObject HudPrefab;
      public GameObject InventoryPrefab;
   }
}