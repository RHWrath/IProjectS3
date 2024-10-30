using Microsoft.EntityFrameworkCore;
using Main.ViewModels;
using DAL;
using Logic.Models;
using Logic.Interfaces;
using Logic.Services;

namespace Main.Controllers
{
    public static class CatController
    {
        public static void SetupCat(this WebApplication app)
        {
            app.MapGet("/Cat", (DatabaseContext db) =>
            {
                ICatDAL catDAL = new CatDAL(db);
                CatService catService = new CatService(catDAL);

                
            })
            .WithName("GetCats")
            .WithOpenApi()
            .WithDescription("Gets Information of all the Cats");
        }
    }
}
