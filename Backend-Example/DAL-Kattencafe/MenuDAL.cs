using Logic.Models;
using Logic.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace DAL
{
    public class MenuDAL : IMenuCardDAL
    {
        private DbSet<MenuCardModel> MenuSet { get; set; }

        public MenuDAL(DatabaseContext DBC)
        {
            MenuSet = DBC.MenuCards;
        }

        public List<MenuCardModel> GetMenuCards()
        {


            throw new NotImplementedException();


        }


    }
}
