using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Game.Hero
{
   public class HeroMover : MonoBehaviour
   {
      [SerializeField] private Rigidbody2D _rb;
      [SerializeField] private float _speed;
      
      private IInputService _inputService;
      private Vector2 _lookDir = Vector2.down;

      public void Construct(IInputService inputService)
      {
         _inputService = inputService;
         inputService.Move += Move;
      }

      public Vector2 GetLookDir() =>
         _lookDir;

      private void OnDestroy() => 
         _inputService.Move -= Move;

      private void Move(Vector2 dir)
      {
         _lookDir = dir;
         _rb.AddForce(_lookDir * _speed, ForceMode2D.Impulse);
      }
   }
}