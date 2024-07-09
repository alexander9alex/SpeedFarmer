using CodeBase.Game.InventoryDir;
using CodeBase.Game.PlaceToGrow;
using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Game.Tools
{
   public class Hoe : MonoBehaviour, ITool
   {
      private const string PlaceToGrowLayerName = "PlaceToGrow";
      private LayerMask _placeToGrowLayerMask;
      private const float Distance = 0.7f;
      private static readonly Vector3 CollisionBoxSize = new(.05f, .05f, 1);
      
      public Sprite Icon => _icon;
      [SerializeField] private Sprite _icon;
      private IHeroHitFinder _heroHitFinder;

      public void Construct(IHeroHitFinder heroHitFinder)
      {
         _heroHitFinder = heroHitFinder;
         _placeToGrowLayerMask = 1 << LayerMask.NameToLayer(PlaceToGrowLayerName);
      }

      public void Use()
      {
         // сыграть анимацию
         
         RaycastHit2D hit = _heroHitFinder.GetHitWithMask(CollisionBoxSize, Distance, _placeToGrowLayerMask);
         if (hit.collider != null)
            hit.collider.GetComponent<IPlaceToGrow>().Plow();
         
         Debug.Log("Hoe used!");
      }

      public GameObject InstantiateView(Vector3 pos)
      {
         transform.position = pos; 
         gameObject.SetActive(true);
         return gameObject;
      }

      public void DestroyView() =>
         gameObject.SetActive(false);
   }
}