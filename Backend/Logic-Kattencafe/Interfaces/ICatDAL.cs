using Logic.Models;

namespace Logic.Interfaces
{
    public interface ICatDAL
    {
        public List<CatModel> GetCatList();
        public CatModel GetCatByID(int catID);
        void AddNewCat(string CatName, string CatDescription, string? CatIMG);
        void UpdateCat(string CatName, string CatDescription, string CatIMG, int CatID);
        void DeleteCat(int CatID);
    }
}
