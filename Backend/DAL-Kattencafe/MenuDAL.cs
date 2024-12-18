using Logic.Models;
using Logic.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace DAL
{
    public class MenuDAL : IMenuCardDAL
    {
        private DatabaseContext _dbContext;

        public MenuDAL(DatabaseContext DBC)
        {
            _dbContext = DBC;
        }

        public List<MenuCardModel> GetMenuCards()
        {
            List<MenuCardModel> MenuCardList = new();

            foreach (MenuCardModel menuCardModels in _dbContext.MenuCards)
            {
                MenuCardModel MenuModel = new MenuCardModel();
                MenuModel.ID = menuCardModels.ID;
                MenuModel.Name = menuCardModels.Name;
                MenuModel.Description = menuCardModels.Description;
                MenuModel.Price = menuCardModels.Price;

                MenuCardList.Add(MenuModel);
            }
            return MenuCardList;
        }
        
        public MenuCardModel GetMenuByID(int ID)
        {
            return _dbContext.MenuCards.FirstOrDefault(x => x.ID == ID);
        } 

        public void AddMenuItem(string MenuItemName, string MenuItemDescription, double MenuItemPrice)
        {
            if (!string.IsNullOrEmpty(MenuItemName) && !string.IsNullOrEmpty(MenuItemDescription)) 
            {
                _dbContext.Add(new MenuCardModel() { Name = MenuItemName, Description = MenuItemDescription, Price = MenuItemPrice });
                _dbContext.SaveChanges();
            }
        }

        public void UpdateMenuItem(string MenuItemName, string MenuItemDescription, double MenuItemPrice, int MenuCardId)
        {
            if (!string.IsNullOrEmpty(MenuItemName) && !string.IsNullOrEmpty(MenuItemDescription) && MenuCardId != 0)
            {
                MenuCardModel menuCardModel = _dbContext.MenuCards.Where(MC => MC.ID == MenuCardId).FirstOrDefault();
                menuCardModel.Name = MenuItemName;
                menuCardModel.Description = MenuItemDescription;
                menuCardModel.Price = MenuItemPrice;
                _dbContext.SaveChanges();
            }
        }

        public void DeleteMenuItem(int MenuCardId)
        {
            if (MenuCardId != 0)
            {
                _dbContext.MenuCards.Remove(new MenuCardModel { ID = MenuCardId });
                _dbContext.SaveChanges();
            }
        }
    }
}
