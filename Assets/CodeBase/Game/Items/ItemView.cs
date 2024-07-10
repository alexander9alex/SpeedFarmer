using UnityEngine;

namespace CodeBase.Game.Items
{
   public class ItemView : MonoBehaviour, IItemView
   {
      public IItem Item { get; private set; }

      public void Construct(IItem item) =>
         Item = item;

      public void Destroy() =>
         Destroy(gameObject);
   }
}