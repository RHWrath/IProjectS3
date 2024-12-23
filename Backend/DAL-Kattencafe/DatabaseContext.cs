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
             string environment = Environment.GetEnvironmentVariable("DatabaseConnection");
             string connectionString = "empty";
            
             Console.WriteLine($"environment:" + environment);
             
             if (environment == "Development")
             {
                 connectionString = _configuration.GetConnectionString("DevelopmentDB");
             }
             else
             {
                 Console.WriteLine("Using Server");
                 connectionString = _configuration.GetConnectionString("ProductionDB");
             }
             
             options.UseSqlServer(connectionString);
        }
    }
}
