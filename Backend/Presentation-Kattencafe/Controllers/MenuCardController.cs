using Main.ViewModels;
using DAL;
using Logic.Models;
using Logic.Interfaces;
using Logic;
using System.Text.RegularExpressions;

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
            
            group.MapGet("/{MenuID}", (DatabaseContext db, int MenuID) =>
            {
                IMenuCardDAL menuCardDal = new MenuDAL(db);
                MenuCardLogic menuCardLogic = new MenuCardLogic(menuCardDal);
                MenuCardModel menuCardModel = new ();
                MenuCardViewModel menuCardViewModel = new();
                List<MenuCardViewModel> MenuList = new ();
                
                menuCardModel = menuCardLogic.GetMenuByID(MenuID);
                
                menuCardViewModel.ID = menuCardModel.ID;
                menuCardViewModel.Name = menuCardModel.Name;
                menuCardViewModel.Description = menuCardModel.Description;
                menuCardViewModel.Price = menuCardModel.Price;
                
                MenuList.Add(menuCardViewModel);
                
                return MenuList;
            })
            .WithName("GetSingleMenuCard")
            .WithOpenApi()
            .WithDescription("Gets Information of the entire menu card");
            
            group.MapPost("/",
                    (DatabaseContext db,string MenuItemName, string MenuItemDescription, double Price) =>
            {
                Regex regex = new Regex("^[A-Za-z0-9 .]+$");
                if (string.IsNullOrWhiteSpace(MenuItemName) || string.IsNullOrWhiteSpace(MenuItemDescription))
                {
                    return Results.BadRequest();
                }
                if (!regex.IsMatch(MenuItemName)) { return Results.BadRequest();}
                    
                if (!regex.IsMatch(MenuItemDescription)) { return Results.BadRequest();}
                
                IMenuCardDAL MenuDAL = new MenuDAL(db);
                MenuCardLogic menuCardLogic = new MenuCardLogic(MenuDAL);
                menuCardLogic.AddMenuItem(MenuItemName, MenuItemDescription, Price);
                return Results.Created();
            })
                .WithName("CreateMenuItem")
                .WithOpenApi()
                .WithDescription("Creates a new menu card");
            
            group.MapPut("/{MenuCardID}",
                (DatabaseContext db, string MenuItemName, string MenuItemDescription, double Price, int MenuCardId) =>
            {
                Regex regex = new Regex("^[A-Za-z0-9 .]+$");
                if (string.IsNullOrWhiteSpace(MenuItemName) || string.IsNullOrWhiteSpace(MenuItemDescription))
                {
                    return Results.BadRequest("Naam & Description is Vereist");
                }
                if (!regex.IsMatch(MenuItemName)) { return Results.BadRequest("Naam is fout");}
                    
                if (!regex.IsMatch(MenuItemDescription)) { return Results.BadRequest("Description is fout");}
                
                IMenuCardDAL MenuDAL = new MenuDAL(db);
                MenuCardLogic menuCardLogic = new MenuCardLogic(MenuDAL);
                menuCardLogic.UpdateMenuItem(MenuItemName, MenuItemDescription, Price, MenuCardId);
                return Results.Created();
            })
                .WithName("UpdateMenuItem")
                .WithOpenApi()
                .WithDescription("Updates a new menu card");
            
            group.MapDelete("/{MenuCardID}", (DatabaseContext db, int MenuCardID) =>
            {
                IMenuCardDAL MenuDAL = new MenuDAL(db);
                MenuCardLogic menuCardLogic = new MenuCardLogic(MenuDAL);
                menuCardLogic.DeleteMenuItem(MenuCardID);
                return Results.Ok();
            })
                .WithName("DeleteMenuItem")
                .WithOpenApi()
                .WithDescription("Deletes a menu card");
            return group;
        }
    }
}
