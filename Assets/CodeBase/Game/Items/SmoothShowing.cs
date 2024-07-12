using System.Collections;
using UnityEngine;

namespace CodeBase.Game.Items
{
   public class SmoothShowing : MonoBehaviour
   {
      private const float MaxDistanceDelta = 0.2f;

      public void StartShowing()
      {
         Vector3 localScale = transform.lossyScale;
         transform.localScale = localScale / 10;
         StartCoroutine(IncreaseGo(localScale));
      }

      private IEnumerator IncreaseGo(Vector3 endScale)
      {
         while (transform.localScale.magnitude < endScale.magnitude)
         {
            transform.localScale = Vector3.MoveTowards(transform.localScale, endScale, MaxDistanceDelta);
            yield return null;
         }
         
         Destroy(this);
      }
   }
}