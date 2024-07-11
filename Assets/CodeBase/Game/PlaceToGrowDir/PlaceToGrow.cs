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
         _currentSeed = seed;
         _currentPlantSpriteId = 0;
         _currentPlantState = PlantState.Grown;

         _plantSr.sprite = _currentSeed.SeedData.GrowSprites[0];
         _inventory.DropItem();

         UpdateDirt(PlaceToGrowDirt.Simple);
         CreateGrowPlant();

         Debug.Log("Planted!");
      }

      private void OnGrow()
      {
         _currentPlantSpriteId++;

         if (IsGrown())
         {
            _plantSr.sprite = _currentSeed.SeedData.GrownSprite;
            _currentPlantState = PlantState.Grown;
         }
         else
         {
            _plantSr.sprite = _currentSeed.SeedData.GrowSprites[_currentPlantSpriteId];
            CreateGrowPlant();
         }
      }

      private void CreateGrowPlant()
      {
         EcsEntity entity = _world.NewEntity();
         ref GrowingPlant growingPlant = ref entity.Get<GrowingPlant>();
         growingPlant.GrowTime = _currentSeed.SeedData.GrowTime;
         growingPlant.OnGrow = OnGrow;
      }

      private void UpdateDirt(PlaceToGrowDirt dirtState)
      {
         _currentDirtState = dirtState;
         _dirtSr.sprite = GetDirtSprite(_currentDirtState);
      }

      public bool CanPlow() =>
         _currentDirtState == PlaceToGrowDirt.Simple;

      public bool CanPlant() =>
         _currentPlantState == PlantState.Empty &&
         _currentDirtState == PlaceToGrowDirt.Plowed;

      private bool IsGrown() =>
         _currentPlantSpriteId > _currentSeed.SeedData.GrowSprites.Count - 1;

      private Sprite GetDirtSprite(PlaceToGrowDirt dirtState) =>
         _placeToGrowData.DirtSprites.First(state => state.SpriteType == dirtState).Sprite;
   }
}