using Microsoft.EntityFrameworkCore;
using DataModels;
using Backend_Example.ViewModels;

namespace Backend_Example.Service
{
    public static class CatController
    {
        public static void SetupCat(this WebApplication app)
        {
            app.MapGet("/Cat", (DatabaseContext db) =>
            {
                DbSet<CatDataModel> cats = db.CatLists;

                List<CatViewModel> catViewModels = new();

                foreach (CatDataModel cat in cats)
                {
                    CatViewModel catViewModel = new();

                    catViewModel.ID = cat.ID;
                    catViewModel.Name = cat.Name;
                    catViewModel.Description = cat.Description;
                    catViewModel.IMG = cat.IMG;

                    catViewModels.Add(catViewModel);
                }

                return catViewModels;
            })
            .WithName("GetCats")
            .WithOpenApi()
            .WithDescription("Gets Information of all the Cats");
        }
    }
}
