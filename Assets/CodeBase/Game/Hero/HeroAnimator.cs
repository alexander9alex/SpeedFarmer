using CodeBase.Services;
using UnityEngine;
using Zenject;

namespace CodeBase.Game.Hero
{
   public class HeroAnimator : MonoBehaviour
   {
      private static readonly int LookDirInDeg = Animator.StringToHash("LookDirInDeg");
      private static readonly int Speed = Animator.StringToHash("Speed");

      [SerializeField] private Animator _animator;
      [SerializeField] private Rigidbody2D _rb;
      
      private IInputService _inputService;

      [Inject]
      private void Construct(IInputService inputService)
      {
         _inputService = inputService;
         _inputService.Move += SetLookDir;
      }

      private void OnDestroy() => 
         _inputService.Move -= SetLookDir;

      private void Update() =>
         _animator.SetFloat(Speed, _rb.velocity.magnitude);

      private void SetLookDir(Vector2 dir)
      {
         if (dir.y > 0)
            SetLookDir(90);
         else if (dir.y < 0)
            SetLookDir(270);
         else if (dir.x > 0)
            SetLookDir(0);
         else if (dir.x < 0)
            SetLookDir(180);
      }

      private void SetLookDir(int deg) =>
         _animator.SetInteger(LookDirInDeg, deg);
   }
}