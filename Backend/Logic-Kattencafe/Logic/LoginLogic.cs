using Logic.Interfaces;
using Logic.Models;

namespace Logic
{
    public class LoginLogic
    {
        private ILoginDAL LoginDal { get; } 
        public LoginLogic(ILoginDAL loginDal) 
        { this.LoginDal = loginDal; }

        public UserAcountModel GetUserAcount(string username)
        {
            return LoginDal.GetUserLogin(username);
        }

        public bool CheckLogin(string username, string password)
        {
            string Username = GetUserAcount(username).UserName;
            string Password = GetUserAcount(username).Password;
            
            if (username == Username && password == Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}