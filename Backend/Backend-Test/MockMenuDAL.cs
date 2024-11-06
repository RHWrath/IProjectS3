using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Interfaces;
using Logic.Models;

namespace Backend_Test
{
    public class MockMenuDAL : IMenuCardDAL
    {
        public int ID = 1;
        public string Name = "Coffee";
        public string Description = "empty";
        public double Price = 0;
        public bool IsActive = false;

        public List<MenuCardModel> GetMenuCards()
        {
            IsActive = true;
            return new List<MenuCardModel>() { new MenuCardModel() 
            {
                ID  = ID,
                Name = Name,
                Description = Description,
                Price = Price
            } 
            };
        
        }


    }
}
