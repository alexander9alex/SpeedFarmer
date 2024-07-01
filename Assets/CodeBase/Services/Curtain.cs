using System;
using System.Collections;
using CodeBase.Data;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.Services
{
   public class Curtain : MonoBehaviour, ICurtain
   {
      [SerializeField] private Image _curtain;
      [SerializeField] private float _curtainChangeStep;

      private ICoroutineRunner _coroutineRunner;

      [Inject]
      private void Construct(ICoroutineRunner coroutineRunner) =>
         _coroutineRunner = coroutineRunner;

      public void Show(Action onShowed = null) =>
         _coroutineRunner.StartCoroutine(ChangeBlackoutCoroutine(onShowed, 0, 1, _curtainChangeStep));

      public void Hide(Action onHided = null)
      {
         onHided += () => _curtain.gameObject.SetActive(false);
         _coroutineRunner.StartCoroutine(ChangeBlackoutCoroutine(onHided, 1, 0, -_curtainChangeStep));
      }

      private IEnumerator ChangeBlackoutCoroutine(Action onEnded, int startValue, int endValue, float step)
      {
         SetBlackoutAlpha(startValue);
         _curtain.gameObject.SetActive(true);

         while (Math.Abs(_curtain.color.a - endValue) > MathValues.FloatCompareDelta)
         {
            SetBlackoutAlpha(_curtain.color.a + step);
            yield return null;
         }

         onEnded?.Invoke();
      }

      private void SetBlackoutAlpha(float alpha) =>
         _curtain.color = new Color(_curtain.color.r, _curtain.color.g, _curtain.color.b, alpha);
   }
}