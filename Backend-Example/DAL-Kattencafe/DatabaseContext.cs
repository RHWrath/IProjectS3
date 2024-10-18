using Microsoft.EntityFrameworkCore;
using Logic_Kattencafe.Models;

namespace DAL_Kattencafe
{
    public class DatabaseContext : DbContext
    {
        public DbSet<CatModel> CatLists { get; set; }
        public DbSet<MenuCardModel> MenuCards { get; set; }

        private const string con = $"Server=mssqlstud.fhict.local;Database=dbi514798_ips3;user id=dbi514798_ips3;password=SWW#1;TrustServerCertificate=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(con);
    }
}
