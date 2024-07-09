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
         
         OnItemChanged(_inventory.GetItem());
      }
      
      private void OnItemChanged(ITool tool) =>
         _itemIcon.sprite = tool != null ? tool.Icon : _nullItemSprite;
   }
}