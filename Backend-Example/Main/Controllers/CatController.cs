using Microsoft.EntityFrameworkCore;
using Main.ViewModels;
using DAL;
using Logic.Models;
using Logic.Interfaces;
using Logic;

namespace Main.Controllers
{
    public static class CatController
    {
        public static void SetupCat(this WebApplication app)
        {
            app.MapGet("/Cat", (DatabaseContext db) =>
            {
                ICatDAL catDAL = new CatDAL(db);
                CatLogic catlogic = new CatLogic(catDAL);
                List<CatViewModel> Catlist = new ();

                foreach (CatModel catModel in catlogic.GetCats())
                {
                    CatViewModel catViewModel = new();

                    catViewModel.ID = catModel.ID;
                    catViewModel.Name = catModel.Name;
                    catViewModel.Description = catModel.Description;
                    catViewModel.IMG = catModel.IMG;

                    Catlist.Add(catViewModel);
                }
                return Catlist;
                
            })
            .WithName("GetCats")
            .WithOpenApi()
            .WithDescription("Gets Information of all the Cats");
        }
    }
}
