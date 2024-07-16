using CodeBase.Game.Items;
using CodeBase.StaticData;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Game.InventoryDir
{
   public class InventoryView : MonoBehaviour
   {
      [SerializeField] private Image _itemIcon;
      [SerializeField] private RectTransform _dropsOfWaterParent;

      private InventoryData _inventoryData;
      private IInventory _inventory;

      public void Construct(InventoryData inventoryData, IInventory inventory)
      {
         _inventoryData = inventoryData;
         _inventory = inventory;
         _inventory.ItemChanged += OnItemChanged;
         _inventory.DropsOfWaterChanged += DropsOfWaterChanged;

         OnItemChanged(_inventory.GetItemData());
      }

      private void OnDestroy()
      {
         _inventory.ItemChanged -= OnItemChanged;
         _inventory.DropsOfWaterChanged -= DropsOfWaterChanged;
      }

      private void DropsOfWaterChanged(DropsOfWater dropsOfWater)
      {
         DestroyDropsOfWater();
         CreateDropsOfWater(dropsOfWater);
      }

      private void OnItemChanged(IItem item)
      {
         _itemIcon.sprite = item != null ? item.Icon : _inventoryData.NullItemSprite;

         if (item is WateringCan wateringCan)
            CreateDropsOfWater(wateringCan.GetDropsOfWater());
         else
            DestroyDropsOfWater();
      }

      private void CreateDropsOfWater(DropsOfWater dropsOfWater)
      {
         for (int i = 0; i < dropsOfWater.AllDropsCount; i++)
         {
            if (i < dropsOfWater.CurrentDropsCount)
               CreateDropOfWater(_inventoryData.FullDropOfWaterPrefab);
            else
               CreateDropOfWater(_inventoryData.EmptyDropOfWaterPrefab);
         }
      }

      private void CreateDropOfWater(GameObject prefab) =>
         Instantiate(prefab, _dropsOfWaterParent);

      private void DestroyDropsOfWater()
      {
         if (!_dropsOfWaterParent.gameObject.activeSelf)
            return;

         foreach (Transform dropOfWater in _dropsOfWaterParent.GetComponentsInChildren<Transform>())
            if (dropOfWater != _dropsOfWaterParent)
               Destroy(dropOfWater.gameObject);
      }
   }
}