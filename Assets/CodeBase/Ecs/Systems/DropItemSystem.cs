using System;
using CodeBase.Ecs.Components;
using CodeBase.Game.Hero;
using CodeBase.Game.Items;
using CodeBase.Infrastructure.Factories;
using Leopotam.Ecs;
using UnityEngine;

namespace CodeBase.Ecs.Systems
{
   public class DropItemSystem : IEcsRunSystem
   {
      private const float Distance = .5f;
      private const float Force = 6f;
      private const float DropWithSpeedCoef = 2f;

      private EcsFilter<DropItemRequest> _requests;
      private EcsFilter<Hero> _heroes;

      private readonly IToolsFactory _toolsFactory;
      private readonly ISeedsFactory _seedsFactory;
      private readonly IFruitsFactory _fruitsFactory;

      public DropItemSystem(IToolsFactory toolsFactory, ISeedsFactory seedsFactory, IFruitsFactory fruitsFactory)
      {
         _toolsFactory = toolsFactory;
         _seedsFactory = seedsFactory;
         _fruitsFactory = fruitsFactory;
      }

      public void Run()
      {
         foreach (var i in _requests)
         {
            foreach (int j in _heroes)
            {
               IItem item = _requests.Get1(i).ItemData;
               GameObject hero = _heroes.Get1(j).HeroGo;

               DropItem(item, hero);
            }

            _requests.GetEntity(i).Destroy();
         }
      }

      private void DropItem(IItem item, GameObject hero)
      {
         Vector2 lookDir = hero.GetComponent<HeroMover>().GetLookDir();
         Vector3 pos = hero.transform.position + new Vector3(lookDir.x, lookDir.y) * Distance;
         GameObject itemGo = CreateItem(item, pos);

         itemGo.AddComponent<SmoothShowing>().StartShowing();
         itemGo.GetComponent<Rigidbody2D>()
            .AddForce(lookDir * Force + lookDir * hero.GetComponent<Rigidbody2D>().velocity.magnitude * DropWithSpeedCoef,
               ForceMode2D.Impulse);
      }

      private GameObject CreateItem(IItem item, Vector3 pos)
      {
         GameObject itemGo;
         switch (item)
         {
            case ITool tool:
               itemGo = _toolsFactory.CreateTool(tool.ToolData.ToolType, pos);
               break;
            case ISeed seed:
               itemGo = _seedsFactory.CreateSeed(seed.SeedData.SeedType, pos);
               break;
            case IFruit fruit:
               itemGo = _fruitsFactory.CreateFruit(fruit.FruitData.SeedType, pos);
               break;
            default:
               throw new ArgumentOutOfRangeException(nameof(item));
         }

         return itemGo;
      }
   }
}