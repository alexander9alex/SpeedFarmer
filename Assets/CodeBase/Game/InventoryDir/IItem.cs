using CodeBase.Data;
using UnityEngine;

namespace CodeBase.Game.InventoryDir
{
   public interface IItem : IInteractable
   {
      public Sprite Icon { get; }
      public void Use();
      public GameObject InstantiateView(Vector3 pos);
      public void DestroyView();
   }
}