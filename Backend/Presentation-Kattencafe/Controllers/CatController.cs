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
            app.MapGet("/GetCats", (DatabaseContext db) =>
            {
                ICatDAL catDAL = new CatDAL(db);
                CatLogic catlogic = new CatLogic(catDAL);
                List<CatViewModel> Catlist = new ();

                foreach (CatModel catModel in catlogic.GetCats())
                {
                    CatViewModel catViewModel = new();

                    catViewModel.CatID = catModel.ID;
                    catViewModel.CatName = catModel.Name;
                    catViewModel.CatDescription = catModel.Description;
                    catViewModel.CatIMG = catModel.IMG;

                    Catlist.Add(catViewModel);
                }
                return Catlist;
                
            })
            .WithName("GetCats")
            .WithOpenApi()
            .WithDescription("Gets Information of all the Cats");

            app.MapPost("/CreateCat", 
                (DatabaseContext db, string CatName, String CatDescription, string? CatIMG) => 
            {
                ICatDAL catDAL = new CatDAL(db);
                CatLogic catlogic = new CatLogic(catDAL);
                catlogic.AddCat(CatName, CatDescription, CatIMG);
            })
            .WithName("CreateCat")
            .WithOpenApi()
            .WithDescription("Creates a Cat");
            
            app.MapPut("/UpdateCat",
                (DatabaseContext db, string CatName, String CatDescription, string? CatIMG, int CatID) =>
                    {
                        ICatDAL catDAL = new CatDAL(db);
                        CatLogic catlogic = new CatLogic(catDAL);
                        catlogic.UpdateCat(CatName, CatDescription, CatIMG, CatID);
                    })
                    .WithName("UpdateCat")
                    .WithOpenApi()
                    .WithDescription("Updates a Cat");
            
            app.MapDelete("/DeleteCat",
                    (DatabaseContext db, int CatID) =>
                    {
                        ICatDAL catDAL = new CatDAL(db);
                        CatLogic catlogic = new CatLogic(catDAL);
                        catlogic.DeleteCat(CatID);
                    })
                    .WithName("DeleteCat")
                    .WithOpenApi()
                    .WithDescription("Deletes a Cat");
                }
    }
}
