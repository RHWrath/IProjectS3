using Microsoft.EntityFrameworkCore;
using Main.ViewModels;
using DAL;
using Logic.Models;
using Logic.Interfaces;
using Logic;

namespace Main.Controllers
{
    public static class MenuCardController
    {
        public static void SetupMenuCard(this WebApplication app)
        {
            app.MapGet("/MenuCard", (DatabaseContext db) =>
            {
                IMenuCardDAL MenuDAL = new MenuDAL(db);
                MenuCardLogic menuCardLogic = new MenuCardLogic(MenuDAL);
                List<MenuCardViewModel> MenuCardList = new();

                foreach (MenuCardModel menuModel in menuCardLogic.GetMenuCards())
                {
                    MenuCardViewModel menuCardViewModel = new();

                    menuCardViewModel.ID = menuModel.ID;
                    menuCardViewModel.Name = menuModel.Name;
                    menuCardViewModel.Description = menuModel.Description;
                    menuCardViewModel.Price = menuModel.Price;

                    MenuCardList.Add(menuCardViewModel);
                }
                return MenuCardList;
            })
            .WithName("GetMenuCard")
            .WithOpenApi()
            .WithDescription("Gets Information of the entire menu card");
        }
    }
}
