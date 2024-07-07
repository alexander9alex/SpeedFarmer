using CodeBase.Infrastructure.States;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
   public class GameStateMachineInstaller : MonoInstaller
   {
      public override void InstallBindings()
      {
         Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
         Container.BindInterfacesAndSelfTo<InitSystemsState>().AsSingle();
         Container.BindInterfacesAndSelfTo<LoadProgressState>().AsSingle();
         Container.BindInterfacesAndSelfTo<LoadMainMenuState>().AsSingle();
         Container.BindInterfacesAndSelfTo<LoadGameState>().AsSingle();
         Container.BindInterfacesAndSelfTo<GameLoopState>().AsSingle();

         Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();
      }
   }
}