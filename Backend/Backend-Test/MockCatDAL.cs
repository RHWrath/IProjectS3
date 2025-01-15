using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Interfaces;
using Logic.Models;

namespace Backend_Test
{
    public class MockCatDAL : ICatDAL
    {
        public bool IsActive = false;
        public bool iscreated = false;
        public bool IsUpdated = false;
        public bool IsDeleted = false;

        public List<CatModel> Cats { get; } =
        [
            new() { ID = 1, Name = "sphinx", Description = "empty", IMG = "empty" },
            new() { ID = 2, Name = "tester", Description = "empty", IMG = "empty" }
        ];
            

        public List<CatModel> GetCatList()
        {
            IsActive = true;
            return Cats;

        }

        public CatModel GetCatByID(int catID)
        {
            IsActive = true;
            return Cats.FirstOrDefault(x => x.ID == catID);
        }

        public void AddNewCat(string CatName, string CatDescription, string CatIMG)
        {
            IsActive = true;
            Cats.Add(new CatModel { Name = CatName, Description = CatDescription, IMG = CatIMG });
            if (Cats.Count == 3) { iscreated = true; }
        }

        public void UpdateCat(string CatName, string CatDescription, string CatIMG, int CatID)
        {
            IsActive = true;
            Cats[CatID].Name = CatName;
            Cats[CatID].Description = CatDescription;
            Cats[CatID].IMG = CatIMG;
            
            if (Cats[CatID].Name == CatName) { IsUpdated = true; }
        }

        public void DeleteCat(int CatID)
        {
            IsActive = true;
            Cats.RemoveAt(CatID);
            if (Cats.Count == 1) { IsDeleted = true; }
        }
    }
}
