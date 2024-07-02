using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Game.Hero
{
   public class HeroMover : MonoBehaviour
   {
      [SerializeField] private Rigidbody2D _rb;
      [SerializeField] private float _speed;
      
      private IInputService _inputService;

      public void Construct(IInputService inputService)
      {
         _inputService = inputService;
         inputService.Move += Move;
      }
      
      private void OnDestroy() => 
         _inputService.Move -= Move;

      private void Move(Vector2 dir) => 
         _rb.AddForce(dir * _speed, ForceMode2D.Force);
   }
}