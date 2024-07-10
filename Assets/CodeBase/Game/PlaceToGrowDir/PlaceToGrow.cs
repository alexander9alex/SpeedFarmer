using System.Linq;
using CodeBase.Data;
using CodeBase.Data.PlaceToGrowDir;
using CodeBase.Game.InventoryDir;
using CodeBase.Game.Items;
using CodeBase.Services;
using CodeBase.StaticData;
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
      private PlantState _currentPlantState = PlantState.Empty;
      private IInventory _inventory;

      public void Construct(IInventory inventory, IStaticData staticData)
      {
         _inventory = inventory;
         _placeToGrowData = staticData.GetPlaceToGrowData();
         UpdateDirt(PlaceToGrowDirt.Simple);
      }

      public void Plow() =>
         UpdateDirt(PlaceToGrowDirt.Plowed);

      public void Plant(ISeed seed)
      {
         _currentSeed = seed;
         _currentPlantState = PlantState.Growing;

         _plantSr.sprite = _currentSeed.SeedData.GrowSprites[0];
         _inventory.DropItem();

         UpdateDirt(PlaceToGrowDirt.Simple);
         
         Debug.Log("Planted!");
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

      private Sprite GetDirtSprite(PlaceToGrowDirt dirtState) =>
         _placeToGrowData.DirtSprites.First(state => state.SpriteType == dirtState).Sprite;
   }
}