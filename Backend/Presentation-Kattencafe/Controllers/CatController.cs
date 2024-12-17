﻿using Main.ViewModels;
using DAL;
using Logic.Models;
using Logic.Interfaces;
using Logic;

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

            group.MapGet("/{CatID}", (DatabaseContext db, int ID) =>
            {
                ICatDAL catDAL = new CatDAL(db);
                CatLogic catlogic = new CatLogic(catDAL);
                CatModel catModel = new ();
                CatViewModel catViewModel = new();
                
                catModel = catlogic.GetCatByID(ID);
                
                catViewModel.CatID = catModel.ID;
                catViewModel.CatName = catModel.Name;
                catViewModel.CatDescription = catModel.Description;
                catViewModel.CatIMG = catModel.IMG;
                
                return catViewModel;
            })
            .WithName("Get Cat by ID")
            .WithOpenApi()
            .WithDescription("Gets Information of a cat by ID");
            
            group.MapPost("/", 
                (DatabaseContext db, string CatName, String CatDescription, string? CatIMG) => 
            {
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
