using Main.Controllers;
using DAL;
using Logic.Models;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;

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

builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("Policy", limiterOptions =>
    {
        limiterOptions.PermitLimit = 100;
        limiterOptions.Window = TimeSpan.FromMinutes(1);
    });
});


builder.Services.AddDbContext<DatabaseContext>();


var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    db.Database.Migrate();
    if (db.UserAcounts.FirstOrDefault(u => u.UserName == "BaseAdmin") == null )
        db.UserAcounts.Add(new UserAcountModel{UserName ="BaseAdmin", Password = "BaseAdmin"});
    db.SaveChanges();
}

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRateLimiter();

app.MapGroup("/Cats").SetupCats().WithTags("Cats");
app.MapGroup("/MenuCard").SetupMenuCard().WithTags("MenuCard");
app.MapGroup("/Login").SetupLogin().WithTags("Login");

app.Run();
