namespace CodeBase.Infrastructure.States
{
   public interface IState : IExitableState
   {
      public void Enter();
   }
}