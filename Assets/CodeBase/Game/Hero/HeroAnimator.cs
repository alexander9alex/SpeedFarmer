using System;
using CodeBase.Data;
using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Game.Hero
{
   public class HeroAnimator : MonoBehaviour
   {
      private const float MinSpeedToAnimateWalk = .1f;

      [SerializeField] private Animator _animator;
      [SerializeField] private Rigidbody2D _rb;

      public event Action StartWaitingAnimation;
      private IInputService _inputService;

      private Vector2 _lastLookDir = Vector2.down;
      private string _currentAnim;
      private AnimationWaitState _waitState;
      private Action _onActionCompleted;

      public void Construct(IInputService inputService)
      {
         _inputService = inputService;
         _inputService.Move += SetLookDir;
         StartWaitingAnimation += () => _inputService.ChangeActionMap(ActionMap.UsingItem);
      }

      private void OnDestroy() =>
         _inputService.Move -= SetLookDir;

      private void Update()
      {
         if (_rb.velocity.magnitude > MinSpeedToAnimateWalk)
            ChangeAnimation(HeroAnimationData.Walk);
         else
            ChangeAnimation(HeroAnimationData.Idle);
      }

      public void ActionCompleted()
      {
         _onActionCompleted?.Invoke();
         _onActionCompleted = null;  
      }

      public void AnimationEnded()
      {
         _waitState = AnimationWaitState.NoWaitEnd;
         _inputService.ChangeActionMap(ActionMap.Hero);
      }

      public void ChangeAnimation(string anim, AnimationWaitState waitState = AnimationWaitState.NoWaitEnd,
         Action onActionCompleted = null)
      {
         if (_waitState == AnimationWaitState.WaitEnd)
            return;

         string fullName = GetNameWithLookDir(anim);

         if (_currentAnim == fullName)
            return;

         _animator.Play(fullName);

         _currentAnim = fullName;
         _onActionCompleted = onActionCompleted;

         _waitState = waitState;
         if (_waitState == AnimationWaitState.WaitEnd)
            StartWaitingAnimation?.Invoke();
      }

      private string GetNameWithLookDir(string anim)
      {
         return _lastLookDir.y != 0
            ? AddLookDir(anim, HeroAnimationData.Up, HeroAnimationData.Down, _lastLookDir.y)
            : AddLookDir(anim, HeroAnimationData.Right, HeroAnimationData.Left, _lastLookDir.x);
      }

      private string AddLookDir(string anim, string positive, string negative, float value) =>
         value > 0 ? $"{anim}_{positive}" : $"{anim}_{negative}";

      private void SetLookDir(Vector2 lookDir) =>
         _lastLookDir = lookDir;
   }
}