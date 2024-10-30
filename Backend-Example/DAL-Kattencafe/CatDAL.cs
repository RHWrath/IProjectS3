using DAL;
using Logic.Models;
using Logic.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class CatDAL : ICatDAL
    {
        private DatabaseContext _dbContext;

        public CatDAL(DatabaseContext DBC)
        {
            _dbContext = DBC;     
        }

        public List<CatModel> GetCatList() 
        { 
            List<CatModel> CatList = new();

            foreach (CatModel CatModels in _dbContext.CatLists) 
            { 
                CatModel CatModel = new CatModel();
                CatModel.ID = CatModels.ID;
                CatModel.Name = CatModels.Name;
                CatModel.Description = CatModels.Description;
                CatModel.IMG = CatModels.IMG;

                CatList.Add(CatModel);
            }
            return CatList;      
        
        }


    }
}
