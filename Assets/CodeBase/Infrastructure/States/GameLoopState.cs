using CodeBase.Data;
using CodeBase.Services;

namespace CodeBase.Infrastructure.States
{
   public class GameLoopState : IState
   {
      private readonly IInputService _inputService;
      public GameLoopState(IInputService inputService)
      {
         _inputService = inputService;
      }

      public void Enter()
      {
         _inputService.ChangeActionMap(ActionMap.Hero);
      }

      public void Exit()
      {
         _inputService.ChangeActionMap(ActionMap.UI);
      }
   }
}