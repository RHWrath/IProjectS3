using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Interfaces;
using Logic.Models;

namespace Logic
{
    public class MenuCardLogic
    {
        private IMenuCardDAL MenuCardDAL { get; }
        public MenuCardLogic(IMenuCardDAL MenuDAL)
        {
            this.MenuCardDAL = MenuDAL;
        }

        public List<MenuCardModel> GetMenuCards() { return MenuCardDAL.GetMenuCards(); }

    }
}
