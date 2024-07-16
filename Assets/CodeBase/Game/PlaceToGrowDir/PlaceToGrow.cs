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
using UnityEngine.Rendering;

namespace CodeBase.Game.PlaceToGrowDir
{
   public class PlaceToGrow : MonoBehaviour, IPlaceToGrow
   {
      [SerializeField] private SpriteRenderer _dirtSr;
      [SerializeField] private SpriteRenderer _plantSr;
      [SerializeField] private SortingGroup _plantSortingGroup;
      [SerializeField] private SpriteRenderer _dropOfWaterSr;

      private ISeed _seed;
      private int _plantSpriteId;
      private PlantState _plantState = PlantState.Empty;
      private PlaceToGrowDirt _dirtState = PlaceToGrowDirt.Simple;
      private DropOfWaterState _dropOfWaterState = DropOfWaterState.Disable;

      private IInventory _inventory;
      private EcsWorld _world;
      private PlaceToGrowData _placeToGrowData;
      private EcsEntity _growingPlantEntity;

      public void Construct(IInventory inventory, IStaticData staticData, EcsWorld world)
      {
         _inventory = inventory;
         _world = world;
         _placeToGrowData = staticData.GetPlaceToGrowData();
         UpdateDirt(PlaceToGrowDirt.Simple);
         UpdatePlant(null, PlantState.Empty);
         UpdateDropOfWater(DropOfWaterState.Disable);
      }

      public void Plow() =>
         UpdateDirt(PlaceToGrowDirt.Plowed);

      public void Plant(ISeed seed)
      {
         _inventory.RemoveItem();

         _seed = seed;
         _plantSpriteId = 0;

         UpdateDirt(PlaceToGrowDirt.Simple);
         UpdatePlant(_seed, PlantState.Growing);

         CreateGrowingPlant();

         Debug.Log("Planted!");
      }

      public void Chop()
      {
         ChopPlant(_seed, _plantState);
         UpdatePlant(_seed, PlantState.Empty);
         UpdateDropOfWater(DropOfWaterState.Disable);
         _seed = null;

         Debug.Log("Planted!");
      }

      public void Pour() =>
         ResetPlantWilt();

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
         growingPlant.PlantState = _plantState;
         growingPlant.GrowTime = _seed.SeedData.GrowTime;
         growingPlant.OnGrow = OnGrow;
      }

      private void ResetPlantWilt()
      {
         UpdateDropOfWater(DropOfWaterState.Disable);

         ref GrowingPlant growingPlant = ref _growingPlantEntity.Get<GrowingPlant>();
         growingPlant.WiltTime = _seed.SeedData.WiltTime;
         growingPlant.OnWilt = OnWilt;
         growingPlant.OnDropOfWaterActivate = () => UpdateDropOfWater(DropOfWaterState.Enable);
         growingPlant.DropOfWaterActivateTime = _seed.SeedData.WiltTime / 2;
         growingPlant.IsDropOfWaterActivate = false;
      }

      private void OnGrow()
      {
         _plantSpriteId++;

         if (IsGrown())
         {
            UpdatePlant(_seed, PlantState.Grown);
            UpdateDropOfWater(DropOfWaterState.Disable);
            _growingPlantEntity.Destroy();
         }
         else
         {
            UpdatePlant(_seed, PlantState.Growing);
            ResetPlantGrow();
         }
      }

      private void OnWilt()
      {
         UpdatePlant(_seed, PlantState.Wilted);
         UpdateDropOfWater(DropOfWaterState.Disable);
         _growingPlantEntity.Destroy();

         Debug.Log("Wilted!");
      }

      private void UpdatePlant(ISeed seed, PlantState plantState)
      {
         _plantState = plantState;

         switch (plantState)
         {
            case PlantState.Empty:
               UpdateEmptyPlant();
               break;
            case PlantState.Growing:
               UpdateGrowingPlant(seed);
               break;
            case PlantState.Grown:
               UpdateGrownPlant(seed);
               break;
            case PlantState.Wilted:
               UpdateWiltedPlant(seed);
               break;
            default:
               throw new ArgumentOutOfRangeException(nameof(plantState), plantState, null);
         }
      }

      private void UpdateDropOfWater(DropOfWaterState state)
      {
         _dropOfWaterState = state;

         switch (state)
         {
            case DropOfWaterState.Disable:
               DisableDropOfWater();
               break;
            case DropOfWaterState.Enable:
               EnableDropOfWater();
               break;
            default:
               throw new ArgumentOutOfRangeException(nameof(state), state, null);
         }
      }

      private void UpdateEmptyPlant()
      {
         _plantSr.sprite = null;
         _plantSortingGroup.sortingOrder = -10;
      }

      private void UpdateGrowingPlant(ISeed seed)
      {
         _plantSr.sprite = seed.SeedData.GrowSprites[_plantSpriteId];
         _plantSortingGroup.sortingOrder = seed.SeedData.GrowOrderInLayer[_plantSpriteId];
      }

      private void UpdateGrownPlant(ISeed seed)
      {
         _plantSr.sprite = seed.SeedData.GrownSprite;
         _plantSortingGroup.sortingOrder = 0;
      }

      private void UpdateWiltedPlant(ISeed seed)
      {
         _plantSr.sprite = seed.SeedData.WiltedSprite;
         _plantSortingGroup.sortingOrder = 0;
      }

      private void UpdateDirt(PlaceToGrowDirt dirtState)
      {
         _dirtState = dirtState;
         _dirtSr.sprite = GetDirtSprite(_dirtState);
      }

      public bool CanPlow() =>
         _dirtState == PlaceToGrowDirt.Simple && _plantState == PlantState.Empty;

      public bool CanPlant() =>
         _plantState == PlantState.Empty && _dirtState == PlaceToGrowDirt.Plowed;

      public bool CanChop() =>
         _plantState != PlantState.Empty;

      public bool CanPour() =>
         _plantState == PlantState.Growing && _dropOfWaterState == DropOfWaterState.Enable;

      private void DisableDropOfWater() =>
         _dropOfWaterSr.sprite = null;

      private void EnableDropOfWater() =>
         _dropOfWaterSr.sprite = _placeToGrowData.DropOfWater;

      private bool IsGrown() =>
         _plantSpriteId > _seed.SeedData.GrowSprites.Count - 1;

      private Sprite GetDirtSprite(PlaceToGrowDirt dirtState) =>
         _placeToGrowData.DirtSprites.First(state => state.SpriteType == dirtState).Sprite;
   }
}