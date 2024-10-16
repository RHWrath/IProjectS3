using Microsoft.EntityFrameworkCore;
using EF_core.Models;

namespace EFcore
{
    public class DatabaseContext : DbContext
    {
        public DbSet<CatList> CatLists { get; set; }
        public DbSet<MenuCard> MenuCards { get; set; }

        private const string con = $"Server=mssqlstud.fhict.local;Database=dbi514798_ips3;user id=dbi514798_ips3;password=SWW#1;TrustServerCertificate=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(con);
    }
}
