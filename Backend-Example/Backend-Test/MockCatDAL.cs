﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Interfaces;
using Logic.Models;

namespace Backend_Test
{
    public class MockDAL : ICatDAL
    {
        public int ID = 1;
        public string Name = "spinx";
        public string Description = "empty";
        public string IMG = "empty";

        public List<CatModel> GetCatList()
        {
            return new List<CatModel>() { new CatModel() 
            {
                ID  = ID,
                Name = Name,
                Description = Description,
                IMG = IMG
            } 
            };
        
        }


    }
}
