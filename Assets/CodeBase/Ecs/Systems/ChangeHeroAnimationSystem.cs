using CodeBase.Ecs.Components;
using CodeBase.Game.Hero;
using CodeBase.Services;
using Leopotam.Ecs;

namespace CodeBase.Ecs.Systems
{
   public class ChangeHeroAnimationSystem : IEcsRunSystem
   {
      private EcsFilter<ChangeAnimationRequest> _requests;
      private EcsFilter<Hero> _heroes;

      private readonly IInteractor _interactor;

      public ChangeHeroAnimationSystem(IInteractor interactor)
      {
         _interactor = interactor;
      }

      public void Run()
      {
         foreach (int i in _requests)
         {
            ChangeAnimationRequest changeAnimation = _requests.Get1(i);

            foreach (int j in _heroes)
            {
               Hero hero = _heroes.Get1(j);

               ChangeAnimation(hero, changeAnimation);
            }

            _requests.GetEntity(i).Destroy();
         }
      }

      private void ChangeAnimation(Hero hero, ChangeAnimationRequest animInfo)
      {
         HeroAnimator heroAnimator = hero.HeroGo.GetComponent<HeroAnimator>();
         heroAnimator.ChangeAnimation(animInfo.AnimationName, animInfo.WaitState, animInfo.OnActionCompleted);
      }
   }
}