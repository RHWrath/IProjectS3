using DAL;
using Logic.Models;
using Logic.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CatDAL : ICatDAL
    {
        private DbSet<CatModel> Catset {  get; set; }

        public CatDAL(DatabaseContext DBC)
        {
            Catset = DBC.CatLists;       
        }

        public List<CatModel> GetCatList() 
        { 
            
            
            throw new NotImplementedException(); 
        
        
        }


    }
}
