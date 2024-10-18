using Microsoft.EntityFrameworkCore;
using Main.ViewModels;
using DAL_Kattencafe;
using Logic_Kattencafe.Models;

namespace Main.Controllers
{
    public static class MenuCardController
    {
        public static void SetupMenuCard(this WebApplication app)
        {
            app.MapGet("/MenuCard", (DatabaseContext db) =>
            {
                DbSet<MenuCardModel> Menus = db.MenuCards;

                List<MenuCardViewModel> menuCardViewModels = new();

                foreach (MenuCardModel menu in Menus)
                {
                    MenuCardViewModel menuCardViewModel = new();

                    menuCardViewModel.ID = menu.ID;
                    menuCardViewModel.Name = menu.Name;
                    menuCardViewModel.Description = menu.Description;
                    menuCardViewModel.Price = menu.Price;

                    menuCardViewModels.Add(menuCardViewModel);
                }

                return menuCardViewModels;
            })
            .WithName("GetMenuCard")
            .WithOpenApi()
            .WithDescription("Gets Information of the entire menu card");
        }
    }
}
