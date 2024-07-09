using CodeBase.Data;
using CodeBase.Game.Hero;
using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Game.InventoryDir
{
   public interface ITool : IInteractable
   {
      public void Construct(IHeroHitFinder heroHitFinder, HeroAnimator heroAnimator);
      public Sprite Icon { get; }
      public void Use();
      public GameObject InstantiateView(Vector3 pos);
      public void DestroyView();
   }
}