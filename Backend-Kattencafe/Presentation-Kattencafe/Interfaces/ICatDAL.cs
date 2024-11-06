using Logic.Models;

namespace Logic.Interfaces
{
    public interface ICatDAL
    {
        public List<CatModel> GetCatList();
    }
}
