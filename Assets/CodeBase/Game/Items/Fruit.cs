using CodeBase.Data.Items;
using UnityEngine;

namespace CodeBase.Game.Items
{
   public class Fruit : IFruit
   {
      public FruitData FruitData { get; }
      public Sprite Icon => FruitData.Icon;
      private readonly IItemView _itemView;

      public Fruit(IItemView itemView, FruitData fruitData)
      {
         FruitData = fruitData;

         _itemView = itemView;
         _itemView.Construct(this);
      }

      public void Use() =>
         Debug.Log("Fruit used!");

      public void DestroyView() =>
         _itemView.Destroy();
   }
}