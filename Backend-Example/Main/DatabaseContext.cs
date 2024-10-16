using Microsoft.EntityFrameworkCore;
using DataModels;

namespace Backend_Example
{
    public class DatabaseContext : DbContext
    {
        public DbSet<CatDataModel> CatLists { get; set; }
        public DbSet<MenuCardDataModel> MenuCards { get; set; }

        private const string con = $"Server=mssqlstud.fhict.local;Database=dbi514798_ips3;user id=dbi514798_ips3;password=SWW#1;TrustServerCertificate=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(con);
    }
}
