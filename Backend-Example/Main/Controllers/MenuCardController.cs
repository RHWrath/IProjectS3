using Microsoft.EntityFrameworkCore;
using DataModels;
using Backend_Example.ViewModels;

namespace Backend_Example.Service
{
    public static class MenuCardController
    {
        public static void SetupMenuCard(this WebApplication app)
        {
            app.MapGet("/MenuCard", (DatabaseContext db) =>
            {
                DbSet<MenuCardDataModel> Menus = db.MenuCards;

                List<MenuCardViewModel> menuCardViewModels = new();

                foreach (MenuCardDataModel menu in Menus)
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
