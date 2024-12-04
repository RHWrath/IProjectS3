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
        public static RouteGroupBuilder SetupMenuCard(this RouteGroupBuilder group)
        {
            group.MapGet("/", (DatabaseContext db) =>
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
            
            group.MapPost("/",
                    (DatabaseContext db,string MenuItemName, string MenuItemDescription, double Price) =>
            {
                IMenuCardDAL MenuDAL = new MenuDAL(db);
                MenuCardLogic menuCardLogic = new MenuCardLogic(MenuDAL);
                menuCardLogic.AddMenuItem(MenuItemName, MenuItemDescription, Price);
                
            })
                .WithName("CreateMenuItem")
                .WithOpenApi()
                .WithDescription("Creates a new menu card");
            
            group.MapPut("/",
                (DatabaseContext db, string MenuItemName, string MenuItemDescription, double Price, int MenuCardId) =>
            {
                IMenuCardDAL MenuDAL = new MenuDAL(db);
                MenuCardLogic menuCardLogic = new MenuCardLogic(MenuDAL);
                menuCardLogic.UpdateMenuItem(MenuItemName, MenuItemDescription, Price, MenuCardId);
            })
                .WithName("UpdateMenuItem")
                .WithOpenApi()
                .WithDescription("Updates a new menu card");
            
            group.MapDelete("/", (DatabaseContext db, int MenuCardID) =>
            {
                IMenuCardDAL MenuDAL = new MenuDAL(db);
                MenuCardLogic menuCardLogic = new MenuCardLogic(MenuDAL);
                menuCardLogic.DeleteMenuItem(MenuCardID);
            })
                .WithName("DeleteMenuItem")
                .WithOpenApi()
                .WithDescription("Deletes a menu card");
            return group;
        }
    }
}
