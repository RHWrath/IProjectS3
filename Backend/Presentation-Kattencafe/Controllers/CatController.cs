using System.Text.RegularExpressions;
using Main.ViewModels;
using DAL;
using Logic.Models;
using Logic.Interfaces;
using Logic;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Main.Controllers
{
    public static class CatController
    {
        public static RouteGroupBuilder SetupCats(this RouteGroupBuilder group)
        {
            
            group.MapGet("/", (DatabaseContext db) =>
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

            group.MapGet("/{CatID}", (DatabaseContext db, int CatID) =>
            {
                ICatDAL catDAL = new CatDAL(db);
                CatLogic catlogic = new CatLogic(catDAL);
                CatModel catModel = new ();
                CatViewModel catViewModel = new();
                List<CatViewModel> Catlist = new ();
                
                catModel = catlogic.GetCatByID(CatID);
                
                catViewModel.CatID = catModel.ID;
                catViewModel.CatName = catModel.Name;
                catViewModel.CatDescription = catModel.Description;
                catViewModel.CatIMG = catModel.IMG;
                
                Catlist.Add(catViewModel);
                
                return Catlist;
            })
            .WithName("Get Cat by ID")
            .WithOpenApi()
            .WithDescription("Gets Information of a cat by ID");
            
            group.MapPost("/", 
                (DatabaseContext db, string CatName, String CatDescription, string? CatIMG) =>
                {
                    if (string.IsNullOrWhiteSpace(CatName) || string.IsNullOrWhiteSpace(CatDescription) ||
                        !Regex.IsMatch(CatName, "/^[A-Za-z0-9 ]+$/")
                        || !Regex.IsMatch(CatDescription, "/^[A-Za-z0-9 ]+$/"))
                    { return Results.BadRequest();}
                    
                ICatDAL catDAL = new CatDAL(db);
                CatLogic catlogic = new CatLogic(catDAL);
                catlogic.AddCat(CatName, CatDescription, CatIMG);
                return Results.Created();
            })
            .WithName("CreateCat")
            .WithOpenApi()
            .WithDescription("Creates a Cat");
            
            group.MapPut("/{CatID}",
                (DatabaseContext db, string CatName, String CatDescription, string? CatIMG, int CatID) =>
                    {
                        if (string.IsNullOrWhiteSpace(CatName) || string.IsNullOrWhiteSpace(CatDescription) ||
                            !Regex.IsMatch(CatName, "/^[A-Za-z0-9 ]+$/")
                            || !Regex.IsMatch(CatDescription, "/^[A-Za-z0-9 ]+$/"))
                        { return Results.BadRequest();}
                        
                        ICatDAL catDAL = new CatDAL(db);
                        CatLogic catlogic = new CatLogic(catDAL);
                        catlogic.UpdateCat(CatName, CatDescription, CatIMG, CatID);
                        return Results.Created();
                    })
                    .WithName("UpdateCat")
                    .WithOpenApi()
                    .WithDescription("Updates a Cat");
            
            group.MapDelete("/{CatID}",
                    (DatabaseContext db, int CatID) =>
                    {
                        ICatDAL catDAL = new CatDAL(db);
                        CatLogic catlogic = new CatLogic(catDAL);
                        catlogic.DeleteCat(CatID);
                        return Results.Ok();
                    })
                    .WithName("DeleteCat")
                    .WithOpenApi()
                    .WithDescription("Deletes a Cat");
            return group;
                }
        
    }
}
