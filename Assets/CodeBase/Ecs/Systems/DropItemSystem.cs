using CodeBase.Ecs.Components;
using CodeBase.Game.Hero;
using CodeBase.Game.InventoryDir;
using Leopotam.Ecs;
using UnityEngine;

namespace CodeBase.Ecs.Systems
{
   public class DropItemSystem : IEcsRunSystem
   {
      private const float Distance = .85f;
      private const float Force = 4f;
      private const float DropWithSpeedCoef = 2f;

      private EcsFilter<DropItemRequest> _requests;
      private EcsFilter<Hero> _heroes;
      
      public void Run()
      {
         foreach (var i in _requests)
         {
            foreach (int j in _heroes)
            {
               IItem item = _requests.Get1(i).Item;
               GameObject hero = _heroes.Get1(j).HeroGo;

               DropItem(hero, item);
            }

            _requests.GetEntity(i).Destroy();
         }
      }

      private void DropItem(GameObject hero, IItem item)
      {
         Vector2 lookDir = hero.GetComponent<HeroMover>().GetLookDir();
         Vector3 pos = hero.transform.position + new Vector3(lookDir.x, lookDir.y) * Distance;

         GameObject itemGo = item.InstantiateView(pos);
         itemGo.GetComponent<Rigidbody2D>().AddForce(lookDir * Force + lookDir * hero.GetComponent<Rigidbody2D>().velocity.magnitude * DropWithSpeedCoef, ForceMode2D.Impulse);
      }
   }
}