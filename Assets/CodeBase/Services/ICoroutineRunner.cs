using System.Collections;
using UnityEngine;

namespace CodeBase.Services
{
   public interface ICoroutineRunner
   {
      public Coroutine StartCoroutine(IEnumerator enumerator);
   }
}