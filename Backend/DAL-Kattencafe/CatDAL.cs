using Logic.Models;
using Logic.Interfaces;

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

        public void AddNewCat(string CatName, string CatDescription, string? CatIMG)
        {
            if (!string.IsNullOrEmpty(CatName) && !string.IsNullOrEmpty(CatDescription)) 
            {
                _dbContext.Add(new CatModel { Name = CatName, Description = CatDescription, IMG = CatIMG });
                _dbContext.SaveChanges();
            }
        }

        public void UpdateCat(string CatName, string CatDescription, string? CatIMG, int CatID)
        {
            if (!string.IsNullOrEmpty(CatName) && !string.IsNullOrEmpty(CatDescription) && CatID != 0)
            {
                CatModel catModel = _dbContext.CatLists.Where(CL => CL.ID == CatID).FirstOrDefault();
                catModel.Name = CatName;
                catModel.Description = CatDescription;
                catModel.IMG = CatIMG;
                _dbContext.SaveChanges();
            }
        }

        public void DeleteCat(int CatID)
        {
            if (CatID != 0)
            {
                _dbContext.CatLists.Remove(new CatModel { ID = CatID });
                _dbContext.SaveChanges();
            }
        }

    }
}
