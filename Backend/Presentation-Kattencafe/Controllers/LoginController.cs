using Main.ViewModels;
using DAL;
using Logic.Models;
using Logic.Interfaces;
using Logic;

namespace Main.Controllers
{
    public static class LoginController
    {
        public static RouteGroupBuilder SetupLogin(this RouteGroupBuilder group)
        {
            group.MapPost("/", 
                    (DatabaseContext db, string username, string password) => 
                    {
                        ILoginDAL loginDal = new LoginDAL(db);
                        LoginLogic loginLogic = new LoginLogic(loginDal);
                        if (loginLogic.CheckLogin(username, password))
                        {
                            return Results.Ok();
                        }
                        return Results.NotFound();
                    })
                .WithName("Login")
                .WithOpenApi()
                .WithDescription("Check username and password");

            return group;
        }
    }
}
