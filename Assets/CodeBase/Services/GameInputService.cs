using System;
using CodeBase.Data;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace CodeBase.Services
{
   public class GameInputService : IInputService, ITickable
   {
      public event Action<Vector2> Move;
      public event Action Interact;
      public event Action Drop;

      private readonly Controls _controls = new();
      private Vector2 _movingDir;

      public GameInputService()
      {
         InitHeroActionMap();
         ChangeActionMap(_controls.UI);
      }

      private void InitHeroActionMap()
      {
         _controls.Hero.Move.performed += OnMove;
         _controls.Hero.Move.canceled += OnMove;
         _controls.Hero.Move.Enable();

         _controls.Hero.Interact.started += OnUse;
         _controls.Hero.Interact.Enable();

         _controls.Hero.Drop.started += OnDrop;
         _controls.Hero.Drop.Enable();
      }

      public void ChangeActionMap(ActionMap map)
      {
         switch (map)
         {
            case ActionMap.UI:
               ChangeActionMap(_controls.UI);
               break;
            case ActionMap.Hero:
               ChangeActionMap(_controls.Hero);
               break;
            case ActionMap.UsingItem:
               ChangeActionMap(_controls.UsingItem);
               break;
            default:
               throw new ArgumentOutOfRangeException(nameof(map), map, null);
         }
      }

      private void ChangeActionMap(InputActionMap map)
      {
         if (map.enabled)
            return;
         
         _controls.Disable();
         map.Enable();
      }

      public void Tick()
      {
         if (_movingDir != Vector2.zero)
            Move?.Invoke(_movingDir);
      }

      private void OnDrop(InputAction.CallbackContext context) =>
         Drop?.Invoke();

      private void OnMove(InputAction.CallbackContext context) =>
         _movingDir = context.ReadValue<Vector2>();

      private void OnUse(InputAction.CallbackContext context) =>
         Interact?.Invoke();
   }
}