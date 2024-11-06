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


    }
}
