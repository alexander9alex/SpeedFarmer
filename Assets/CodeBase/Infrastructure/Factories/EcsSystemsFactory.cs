using Zenject;

namespace CodeBase.Infrastructure.Factories
{
   class EcsSystemsFactory : IEcsSystemsFactory
   {
      private readonly DiContainer _container;
      public EcsSystemsFactory(DiContainer container) =>
         _container = container;

      public TSystem CreateSystem<TSystem>() =>
         _container.Resolve<TSystem>();
   }
}