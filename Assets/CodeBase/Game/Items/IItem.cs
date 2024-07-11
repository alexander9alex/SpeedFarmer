using UnityEngine;

namespace CodeBase.Game.Items
{
   public interface IItem : IInteractable
   {
      public Sprite Icon { get; }
      public void Use();
      public void DestroyView();
   }
}