using CodeBase.Data;
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
      private HeroAnimator _heroAnimator;
      private AnimationWaitState _waitState;

      public void Construct(IInputService inputService, HeroAnimator heroAnimator)
      {
         _inputService = inputService;
         inputService.Move += Move;

         _heroAnimator = heroAnimator;
         heroAnimator.StartWaitingAnimation += Stop;
      }

      private void OnDestroy()
      {
         _inputService.Move -= Move;
         _heroAnimator.StartWaitingAnimation -= Stop;
      }

      public Vector2 GetLookDir() =>
         _lookDir;

      private void Stop() =>
         _rb.velocity = Vector2.zero;

      private void Move(Vector2 dir)
      {
         _lookDir = dir;
         _rb.AddForce(_lookDir * _speed, ForceMode2D.Impulse);
      }
   }
}