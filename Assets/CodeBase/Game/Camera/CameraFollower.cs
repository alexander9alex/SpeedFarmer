using UnityEngine;

namespace CodeBase.Game.Camera
{
   public class CameraFollower : MonoBehaviour
   {
      [SerializeField] private float _followInterpolationStep = 0.035f;
      
      private Transform _hero;
      private Vector3 _offsetRelativeHero;
      
      public void Construct(Transform hero)
      {
         _hero = hero;
         _offsetRelativeHero = transform.position;
      }

      private void LateUpdate() => 
         MoveToHero();

      private void MoveToHero() => 
         transform.position = Vector3.Lerp(transform.position, _hero.position + _offsetRelativeHero, _followInterpolationStep);
   }
}