using Logic.Interfaces;
using Logic.Models;

namespace Logic
{
    public class CatLogic
    {
        private ICatDAL CatDAL { get; } 
        public CatLogic(ICatDAL catDAL) 
        { this.CatDAL = catDAL; }

        public List<CatModel> GetCats() 
        { return CatDAL.GetCatList(); }

        public CatModel GetCatByID(int id)
        { return CatDAL.GetCatByID(id); }
        
        public void AddCat(string catName, string CatDescription, string? catIMG)
        { CatDAL.AddNewCat(catName, CatDescription, catIMG);}
        
        public void UpdateCat(string CatName, string CatDescription, string? catIMG, int CatID)
        { CatDAL.UpdateCat(CatName, CatDescription, catIMG, CatID);}
        
        public void DeleteCat(int CatID) 
        { CatDAL.DeleteCat(CatID);}
    }
}
