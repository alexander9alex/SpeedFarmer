using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Data.PlaceToGrowDir;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.StaticData
{
   [CreateAssetMenu(menuName = "Static Data/Place To Grow Data", fileName = "PlaceToGrowData")]
   public class PlaceToGrowData : ScriptableObject
   {
      public GameObject PlaceToGrowPrefab;
      public List<PlaceToGrowDirtSprite> DirtSprites;
      [FormerlySerializedAs("_dropOfWater")]
      public Sprite DropOfWater;
   }
}