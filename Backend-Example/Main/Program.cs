using Backend_Example;
using Backend_Example.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DatabaseContext>();


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Temporary CORS policy to allow all origins
builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod())
);

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.SetupWeather();
app.SetupCat();
app.SetupMenuCard();

app.Run();
