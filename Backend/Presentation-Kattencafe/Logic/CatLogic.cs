using Logic.Interfaces;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class CatLogic
    {
        private ICatDAL CatDAL { get; } 
        public CatLogic(ICatDAL catDAL) 
        {
            this.CatDAL = catDAL;
        }

        public List<CatModel> GetCats() { return CatDAL.GetCatList(); }

    }
}
