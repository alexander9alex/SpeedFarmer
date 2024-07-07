using System;
using CodeBase.Data;
using UnityEngine;

namespace CodeBase.Services
{
   public interface IInputService
   {
      public void ChangeActionMap(ActionMap map);
      public event Action<Vector2> Move;
      public event Action Interact;
      public event Action Drop;
   }
}