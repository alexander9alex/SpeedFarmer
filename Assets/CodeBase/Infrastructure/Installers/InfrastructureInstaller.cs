using CodeBase.Ecs.Systems;
using CodeBase.Game.InventoryDir;
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
         Container.BindInterfacesAndSelfTo<Inventory>().AsSingle();
         
         BindEcs();
         BindFactories();
         BindServices();
      }

      private void BindServices()
      {
         Container.BindInterfacesAndSelfTo<StaticDataService>().AsSingle();
         Container.BindInterfacesAndSelfTo<GameInputService>().AsSingle();
         Container.BindInterfacesAndSelfTo<Interactor>().AsSingle().NonLazy();
         Container.BindInterfacesAndSelfTo<Curtain>().FromInstance(_curtain).AsSingle();
         Container.BindInterfacesAndSelfTo<HeroHitFinder>().AsSingle();
         BindCoroutineRunner();
      }

      private void BindEcs()
      {
         Container.BindInterfacesAndSelfTo<EcsWorld>().AsSingle();
         Container.BindInterfacesAndSelfTo<EcsSystems>().AsSingle();
         BindSystems();
      }

      private void BindFactories()
      {
         Container.BindInterfacesAndSelfTo<GameStateFactory>().AsSingle();
         Container.BindInterfacesAndSelfTo<UIFactory>().AsSingle();
         Container.BindInterfacesAndSelfTo<HeroFactory>().AsSingle();
         Container.BindInterfacesAndSelfTo<CameraFactory>().AsSingle();
         Container.BindInterfacesAndSelfTo<EcsSystemsFactory>().AsSingle();
         Container.BindInterfacesAndSelfTo<LocationFactory>().AsSingle();
         Container.BindInterfacesAndSelfTo<ToolsFactory>().AsSingle();
         Container.BindInterfacesAndSelfTo<PlaceToGrowFactory>().AsSingle();
         Container.BindInterfacesAndSelfTo<SeedsFactory>().AsSingle();
      }

      private void BindCoroutineRunner()
      {
         CoroutineRunner coroutineRunner = new GameObject(CoroutineRunnerName).AddComponent<CoroutineRunner>();
         coroutineRunner.transform.parent = transform.parent;
         Container.BindInterfacesAndSelfTo<CoroutineRunner>().FromInstance(coroutineRunner).AsSingle();
      }

      private void BindSystems()
      {
         Container.BindInterfacesAndSelfTo<TryInteractSystem>().AsSingle();
         Container.BindInterfacesAndSelfTo<DropItemSystem>().AsSingle();
         Container.BindInterfacesAndSelfTo<ChangeHeroAnimationSystem>().AsSingle();
      }
   }
}