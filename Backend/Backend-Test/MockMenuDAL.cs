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
        private int ID = 1;
        private string Name = "Coffee";
        private string Description = "empty";
        private double Price = 0;
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

        public MenuCardModel GetMenuByID(int id)
        {
            throw new NotImplementedException();
        }

        public void AddMenuItem(string MenuItemName, string MenuItemDescription, Double MenuItemPrice)
        {
            throw new NotImplementedException();
        }

        public void UpdateMenuItem(string MenuItemName, string MenuItemDescription, Double MenuItemPrice, int MenuCardId)
        {
            throw new NotImplementedException();
        }

        public void DeleteMenuItem(int MenuCardId)
        {
            throw new NotImplementedException();
        }
    }
}
