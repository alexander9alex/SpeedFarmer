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
      [SerializeField] private GameInputService _inputService;
      
      public override void InstallBindings()
      {
         Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();

         BindEcs();
         BindFactories();
         BindServices();
      }

      private void BindServices()
      {
         Container.BindInterfacesAndSelfTo<StaticDataService>().AsSingle();
         BindInputService();
         BindCoroutineRunner();
         BindCurtain();
      }

      private void BindEcs()
      {
         Container.BindInterfacesAndSelfTo<EcsWorld>().AsSingle();
         Container.BindInterfacesAndSelfTo<EcsSystems>().AsSingle();
      }

      private void BindFactories()
      {
         Container.BindInterfacesAndSelfTo<GameStateFactory>().AsSingle();
         Container.BindInterfacesAndSelfTo<UIFactory>().AsSingle();
         Container.BindInterfacesAndSelfTo<HeroFactory>().AsSingle();
         Container.BindInterfacesAndSelfTo<CameraFactory>().AsSingle();
      }

      private void BindInputService() => 
         Container.BindInterfacesAndSelfTo<IInputService>().FromInstance(_inputService).AsSingle();

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