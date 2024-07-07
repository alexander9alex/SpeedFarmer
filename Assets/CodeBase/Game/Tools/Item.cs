using CodeBase.Game.InventoryDir;
using UnityEngine;

namespace CodeBase.Game.Tools
{
   public class Hoe : MonoBehaviour, IItem
   {
      public Sprite Icon => _icon;
      [SerializeField] private Sprite _icon;

      public void Use() =>
         Debug.Log("Hoe used!");

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