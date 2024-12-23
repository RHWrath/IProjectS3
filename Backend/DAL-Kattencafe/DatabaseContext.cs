using Microsoft.EntityFrameworkCore;
using Logic.Models;

namespace DAL
{
    public class DatabaseContext : DbContext
    {
        public DbSet<CatModel> CatLists { get; set; }
        public DbSet<MenuCardModel> MenuCards { get; set; }
        public DbSet<UserAcountModel> UserAcounts { get; set; }

        private const string devConnection = $"Server=mssqlstud.fhict.local;Database=dbi514798_ips3;user id=dbi514798_ips3;password=SWW#1;TrustServerCertificate=True;";
        private const string liveConnection = $"Server=mssqlstud.fhict.local;Database=dbi514798_ips3live;user id=dbi514798_ips3live;password=TeLangWachtwoord#1;TrustServerCertificate=True;";
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var conn = Environment.GetEnvironmentVariable("ConnectionString");
            if (conn == null) conn = devConnection;
            options.UseSqlServer(conn);
            
        }
    }
}
