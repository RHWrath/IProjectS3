﻿using System;
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
        public int ID = 1;
        public string Name = "spinx";
        public string Description = "empty";
        public string IMG = "empty";
        public bool IsActive = false;

        public List<CatModel> GetCatList()
        {
            IsActive = true;
            return new List<CatModel>() { new CatModel() 
            {
                ID  = ID,
                Name = Name,
                Description = Description,
                IMG = IMG
            } 
            };
        
        }

        public void AddNewCat(string CatName, string CatDescription, string CatIMG)
        {
            throw new NotImplementedException();
        }

        public void UpdateCat(string CatName, string CatDescription, string CatIMG, int CatID)
        {
            throw new NotImplementedException();
        }

        public void DeleteCat(int CatID)
        {
            throw new NotImplementedException();
        }
    }
}
