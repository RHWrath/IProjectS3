
using DAL;
using Logic.Interfaces;
using Logic;

// ReSharper disable once CheckNamespace
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
