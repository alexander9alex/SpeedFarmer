using CodeBase.Data;
using CodeBase.Game.Items;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Game.InventoryDir
{
   public class InventoryView : MonoBehaviour
   {
      [SerializeField] private Image _itemIcon;
      [SerializeField] private Sprite _nullItemSprite;
      
      private IInventory _inventory;

      public void Construct(IInventory inventory)
      {
         _inventory = inventory;
         _inventory.ItemChanged += OnItemChanged;
         
         OnItemChanged(_inventory.GetItemData());
      }
      
      private void OnItemChanged(IItem item) =>
         _itemIcon.sprite = item != null ? item.Icon : _nullItemSprite;
   }
}