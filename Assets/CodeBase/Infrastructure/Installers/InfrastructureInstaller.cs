using CodeBase.Infrastructure.Factories;
using CodeBase.Services;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
   public class InfrastructureInstaller : MonoInstaller
   {
      private const string CoroutineRunnerName = "CoroutineRunner";

      [SerializeField] private Curtain _curtain;

      public override void InstallBindings()
      {
         Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();
         
         BindFactories();
         BindEcs();

         BindCoroutineRunner();
         BindCurtain();
      }

      private void BindFactories()
      {
         Container.BindInterfacesAndSelfTo<GameStateFactory>().AsSingle();
         Container.BindInterfacesAndSelfTo<UIFactory>().AsSingle();
      }

      private void BindEcs()
      {
         Container.BindInterfacesAndSelfTo<EcsWorld>().AsSingle();
         Container.BindInterfacesAndSelfTo<EcsSystems>().AsSingle();
      }

      private void BindCoroutineRunner()
      {
         CoroutineRunner coroutineRunner = new GameObject(CoroutineRunnerName).AddComponent<CoroutineRunner>();
         coroutineRunner.transform.parent = transform;
         DontDestroyOnLoad(coroutineRunner);
         Container.BindInterfacesAndSelfTo<CoroutineRunner>().FromInstance(coroutineRunner).AsSingle();
      }

      private void BindCurtain()
      {
         DontDestroyOnLoad(_curtain);
         Container.BindInterfacesAndSelfTo<Curtain>().FromInstance(_curtain).AsSingle();
      }
   }
}