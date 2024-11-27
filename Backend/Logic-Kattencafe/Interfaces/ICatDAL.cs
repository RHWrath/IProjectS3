using Logic.Models;

namespace Logic.Interfaces
{
    public interface ICatDAL
    {
        public List<CatModel> GetCatList();
        void AddNewCat(string CatName, string CatDescription, string? CatIMG);
        void UpdateCat(string CatName, string CatDescription, string CatIMG, int CatID);
        void DeleteCat(int CatID);
    }
}
