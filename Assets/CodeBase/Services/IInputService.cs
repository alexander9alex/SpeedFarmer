using System;
using UnityEngine;

namespace CodeBase.Services
{
   public interface IInputService
   {
      public event Action<Vector2> Move;
   }
}