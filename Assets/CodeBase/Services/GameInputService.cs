using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CodeBase.Services
{
   class GameInputService : MonoBehaviour, IInputService
   {
      public event Action<Vector2> Move;
      
      private Vector2 _movingDir;

      private void Update()
      {
         if (_movingDir != Vector2.zero)
            Move?.Invoke(_movingDir);
      }

      public void OnMove(InputValue value) => 
         _movingDir = value.Get<Vector2>();
   }
}