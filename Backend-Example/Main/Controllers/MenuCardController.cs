using Microsoft.EntityFrameworkCore;
using Main.ViewModels;
using DAL_Kattencafe.DBContext;
using DAL_Kattencafe.DataModels;

namespace Main.Controllers
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
