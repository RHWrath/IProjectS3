using Microsoft.EntityFrameworkCore;
using Main.ViewModels;
using DAL_Kattencafe;
using Logic_Kattencafe.Models;
using Logic_Kattencafe.Interfaces;
using Presentation_Kattencafe.Services;

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
