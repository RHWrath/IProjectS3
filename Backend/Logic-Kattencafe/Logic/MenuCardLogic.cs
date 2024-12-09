using Logic.Interfaces;
using Logic.Models;

namespace Logic
{
    public class MenuCardLogic
    {
        private IMenuCardDAL MenuCardDAL { get; }
        public MenuCardLogic(IMenuCardDAL MenuDAL)
        {
            this.MenuCardDAL = MenuDAL;
        }

        public List<MenuCardModel> GetMenuCards() { return MenuCardDAL.GetMenuCards(); }
        
        public void AddMenuItem(string menuItemName, string MenuItemDescription, double MenuItemPrice)
        { MenuCardDAL.AddMenuItem(menuItemName, MenuItemDescription, MenuItemPrice);}
        
        public void UpdateMenuItem(string menuItemName, string MenuItemDescription, double MenuItemPrice, int MenuCardId)
        { MenuCardDAL.UpdateMenuItem(menuItemName, MenuItemDescription, MenuItemPrice, MenuCardId);}
        
        public void DeleteMenuItem(int MenuCardId) 
        { MenuCardDAL.DeleteMenuItem(MenuCardId);}

    }
}
