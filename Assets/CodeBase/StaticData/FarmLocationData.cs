using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Data.ToolDir;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.StaticData
{
   [CreateAssetMenu(menuName = "Static Data/Farm Location Data", fileName = "FarmLocationData")]
   public class FarmLocationData : ScriptableObject
   {
      public GameObject FarmPrefab;
      public List<ToolSpawnPointMarker> ToolSpawnPointMarkers;
      [FormerlySerializedAs("PlantSpawnPointMarkers")]
      public List<Vector2> PlaceToGrowSpawnPointMarkers;
   }
}