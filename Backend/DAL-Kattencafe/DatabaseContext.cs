using Microsoft.EntityFrameworkCore;
using Logic.Models;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class DatabaseContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<CatModel> CatLists { get; set; }
        public DbSet<MenuCardModel> MenuCards { get; set; }
        public DbSet<UserAcountModel> UserAcounts { get; set; }
         protected override void OnConfiguring(DbContextOptionsBuilder options)
         {
             string? environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
             string? connectionString = Environment.GetEnvironmentVariable("ConnectionString");
            
             //Console.WriteLine($"environment:" + environment);
             if (connectionString == null)
             {
                 if (environment == "Production")
                 {
                     connectionString = _configuration.GetConnectionString("ProductionDB");
                 }
                 else
                 {
                     //Console.WriteLine("Using DEV");
                     connectionString = _configuration.GetConnectionString("DevelopmentDB");
                 }
             }
             options.UseSqlServer(connectionString);
        }
    }
}
