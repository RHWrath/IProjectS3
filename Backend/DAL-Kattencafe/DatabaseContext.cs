using Microsoft.EntityFrameworkCore;
using Logic.Models;

namespace DAL
{
    public class DatabaseContext : DbContext
    {
        public DbSet<CatModel> CatLists { get; set; }
        public DbSet<MenuCardModel> MenuCards { get; set; }
        public DbSet<UserAcountModel> UserAcounts { get; set; }

        private const string connection = $"Server=mssqlstud.fhict.local;Database=dbi514798_ips3;user id=dbi514798_ips3;password=SWW#1;TrustServerCertificate=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var conn = Environment.GetEnvironmentVariable("ConnectionString");
            if (conn == null) conn = connection;
            options.UseSqlServer(conn);
            
        }
    }
}
