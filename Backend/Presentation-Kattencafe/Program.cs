using Main;
using Main.Controllers;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Temporary CORS policy to allow all origins
builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod())
);

var environment = builder.Environment.EnvironmentName;
var connectionString = environment switch
{
    "Development" => builder.Configuration.GetConnectionString("DevelopmentDB"),
    "Production" => builder.Configuration.GetConnectionString("ProductionDB"),
    _ => throw new Exception($"Environment {environment} is not supported.")
};

Console.WriteLine("GET FUCKED");

//builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<DatabaseContext>();

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGroup("/Cats").SetupCats().WithTags("Cats");
app.MapGroup("/MenuCard").SetupMenuCard().WithTags("MenuCard");
app.MapGroup("/Login").SetupLogin().WithTags("Login");

app.Run();
