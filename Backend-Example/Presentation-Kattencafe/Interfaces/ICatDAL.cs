using Logic_Kattencafe.Models;

namespace Logic_Kattencafe.Interfaces
{
    public interface ICatDAL
    {
        public List<CatModel> GetCatList();
    }
}
