using CodeBase.Data.Items.Seeds;
using CodeBase.Game.Hero;
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
      private readonly ISeedsFactory _seedsFactory;
      private readonly IFruitsFactory _fruitsFactory;

      public LocationFactory(IToolsFactory toolsFactory, IPlaceToGrowFactory placeToGrowFactory, IStaticData staticData,
         ISeedsFactory seedsFactory, IFruitsFactory fruitsFactory)
      {
         _placeToGrowFactory = placeToGrowFactory;
         _seedsFactory = seedsFactory;
         _fruitsFactory = fruitsFactory;
         _toolsFactory = toolsFactory;
         _farmLocationData = staticData.GetFarmLocationData();
      }

      public void CreateFarmLocation(HeroAnimator heroAnimator)
      {
         FarmLocationData farmLocationData = _farmLocationData;
         GameObject farm = Object.Instantiate(farmLocationData.FarmPrefab);

         _toolsFactory.SetParent(farm.transform);
         _placeToGrowFactory.SetParent(farm.transform);
         _seedsFactory.SetParent(farm.transform);
         _fruitsFactory.SetParent(farm.transform);

         _toolsFactory.CreateTools(farmLocationData.ToolSpawnPointMarkers);
         _placeToGrowFactory.CreatePlacesToGrow(farmLocationData.PlaceToGrowSpawnPointMarkers);

         _seedsFactory.CreateSeed(SeedType.Wheat, new Vector3(1, 1));
         _seedsFactory.CreateSeed(SeedType.Wheat, new Vector3(-1, -1));
         _seedsFactory.CreateSeed(SeedType.Wheat, new Vector3(4, -2));
      }
   }
}