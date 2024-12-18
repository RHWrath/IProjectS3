using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IMenuCardDAL
    {
        public List<MenuCardModel> GetMenuCards();
        
        public MenuCardModel GetMenuByID(int id);
        public void AddMenuItem(string MenuItemName, string MenuItemDescription, double MenuItemPrice);
        public void UpdateMenuItem(string MenuItemName, string MenuItemDescription, double MenuItemPrice, int MenuCardId);
        public void DeleteMenuItem(int MenuCardId);
    }
}
