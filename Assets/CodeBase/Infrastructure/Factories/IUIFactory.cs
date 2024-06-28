using CodeBase.Data.Menu;

namespace CodeBase.Infrastructure.Factories
{
   public interface IUIFactory
   {
      public void CreateMenu(MenusType menusType);
   }
}