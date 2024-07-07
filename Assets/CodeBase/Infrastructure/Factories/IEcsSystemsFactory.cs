namespace CodeBase.Infrastructure.Factories
{
   public interface IEcsSystemsFactory
   {
      public TSystem CreateSystem<TSystem>();
   }
}