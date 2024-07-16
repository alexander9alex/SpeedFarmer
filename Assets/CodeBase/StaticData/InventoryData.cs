using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.StaticData
{
   [CreateAssetMenu(menuName = "Static Data/Inventory Data", fileName = "InventoryData")]
   public class InventoryData : ScriptableObject
   {
      public Sprite NullItemSprite;
      public GameObject FullDropOfWaterPrefab;
      public GameObject EmptyDropOfWaterPrefab;
   }
}