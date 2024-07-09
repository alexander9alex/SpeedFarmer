using CodeBase.Services;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Factories
{
   public class LocationFactory : ILocationFactory
   {
      private readonly FarmLocationData _farmLocationData;
      private readonly IToolsFactory _toolsFactory;
      private readonly IPlaceToGrowFactory _placeToGrowFactory;

      public LocationFactory(IToolsFactory toolsFactory, IPlaceToGrowFactory placeToGrowFactory, IStaticData staticData)
      {
         _placeToGrowFactory = placeToGrowFactory;
         _toolsFactory = toolsFactory;
         _farmLocationData = staticData.GetFarmLocationData();
      }

      public void CreateFarmLocation()
      {
         FarmLocationData farmLocationData = _farmLocationData;
         GameObject farm = Object.Instantiate(farmLocationData.FarmPrefab);

         _toolsFactory.CreateTools(farmLocationData.ToolSpawnPointMarkers, farm.transform);
         _placeToGrowFactory.CreatePlacesToGrow(farmLocationData.PlaceToGrowSpawnPointMarkers, farm.transform);
      }
   }
}