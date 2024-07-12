using System;
using System.Linq;
using CodeBase.Data;
using CodeBase.Data.PlaceToGrowDir;
using CodeBase.Ecs.Components;
using CodeBase.Game.InventoryDir;
using CodeBase.Game.Items;
using CodeBase.Services;
using CodeBase.StaticData;
using Leopotam.Ecs;
using UnityEngine;

namespace CodeBase.Game.PlaceToGrowDir
{
   public class PlaceToGrow : MonoBehaviour, IPlaceToGrow
   {
      [SerializeField] private SpriteRenderer _dirtSr;
      [SerializeField] private SpriteRenderer _plantSr;

      private PlaceToGrowData _placeToGrowData;
      private PlaceToGrowDirt _currentDirtState = PlaceToGrowDirt.Simple;

      private ISeed _currentSeed;
      private int _currentPlantSpriteId;
      private PlantState _currentPlantState = PlantState.Empty;

      private IInventory _inventory;
      private EcsWorld _world;
      private EcsEntity _growingPlantEntity;

      public void Construct(IInventory inventory, IStaticData staticData, EcsWorld world)
      {
         _inventory = inventory;
         _world = world;
         _placeToGrowData = staticData.GetPlaceToGrowData();
         UpdateDirt(PlaceToGrowDirt.Simple);
      }

      public void Plow() =>
         UpdateDirt(PlaceToGrowDirt.Plowed);

      public void Plant(ISeed seed)
      {
         _inventory.RemoveItem();

         _currentSeed = seed;
         _currentPlantSpriteId = 0;

         UpdateDirt(PlaceToGrowDirt.Simple);
         UpdatePlant(_currentSeed, PlantState.Growing);

         CreateGrowingPlant();

         Debug.Log("Planted!");
      }

      public void Chop()
      {
         ChopPlant(_currentSeed, _currentPlantState);
         UpdatePlant(_currentSeed, PlantState.Empty);
         _currentSeed = null;

         Debug.Log("Planted!");
      }

      private void CreateGrowingPlant()
      {
         _growingPlantEntity = _world.NewEntity();
         ResetPlantGrow();
         ResetPlantWilt();
      }

      private void ChopPlant(ISeed seed, PlantState plantState)
      {
         EcsEntity entity = _world.NewEntity();
         ref ChopPlant chopPlant = ref entity.Get<ChopPlant>();
         chopPlant.PlantState = plantState;
         chopPlant.Position = transform.position;
         chopPlant.SeedType = seed.SeedData.SeedType;
      }

      private void ResetPlantGrow()
      {
         ref GrowingPlant growingPlant = ref _growingPlantEntity.Get<GrowingPlant>();
         growingPlant.PlantState = _currentPlantState;
         growingPlant.GrowTime = _currentSeed.SeedData.GrowTime;
         growingPlant.OnGrow = OnGrow;
      }

      private void ResetPlantWilt()
      {
         ref GrowingPlant growingPlant = ref _growingPlantEntity.Get<GrowingPlant>();
         growingPlant.WiltTime = _currentSeed.SeedData.WiltTime;
         growingPlant.OnWilt = OnWilt;
      }

      private void OnGrow()
      {
         _currentPlantSpriteId++;

         if (IsGrown())
         {
            UpdatePlant(_currentSeed, PlantState.Grown);
            _growingPlantEntity.Destroy();
         }
         else
         {
            UpdatePlant(_currentSeed ,PlantState.Growing);
            ResetPlantGrow();
         }
      }

      private void OnWilt()
      {
         UpdatePlant(_currentSeed, PlantState.Wilted);
         _growingPlantEntity.Destroy();

         Debug.Log("Wilted!");
      }

      private void UpdatePlant(ISeed seed, PlantState plantState)
      {
         _currentPlantState = plantState;

         switch (plantState)
         {
            case PlantState.Empty:
               _plantSr.sprite = null;
               _plantSr.sortingOrder = -10;
               break;
            case PlantState.Growing:
               _plantSr.sprite = seed.SeedData.GrowSprites[_currentPlantSpriteId];
               _plantSr.sortingOrder = seed.SeedData.GrowOrderInLayer[_currentPlantSpriteId];
               break;
            case PlantState.Grown:
               _plantSr.sprite = seed.SeedData.GrownSprite;
               _plantSr.sortingOrder = 0;
               break;
            case PlantState.Wilted:
               _plantSr.sprite = seed.SeedData.WiltedSprite;
               _plantSr.sortingOrder = 0;
               break;
            default:
               throw new ArgumentOutOfRangeException(nameof(plantState), plantState, null);
         }
      }

      private void UpdateDirt(PlaceToGrowDirt dirtState)
      {
         _currentDirtState = dirtState;
         _dirtSr.sprite = GetDirtSprite(_currentDirtState);
      }

      public bool CanPlow() =>
         _currentDirtState == PlaceToGrowDirt.Simple && _currentPlantState == PlantState.Empty;

      public bool CanPlant() =>
         _currentPlantState == PlantState.Empty && _currentDirtState == PlaceToGrowDirt.Plowed;

      public bool CanChop() =>
         _currentPlantState != PlantState.Empty;

      private bool IsGrown() =>
         _currentPlantSpriteId > _currentSeed.SeedData.GrowSprites.Count - 1;

      private Sprite GetDirtSprite(PlaceToGrowDirt dirtState) =>
         _placeToGrowData.DirtSprites.First(state => state.SpriteType == dirtState).Sprite;
   }
}