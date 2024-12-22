using Logic.Models;

namespace Logic.Interfaces
{
    public interface ILoginDAL
    {
        public UserAcountModel GetUserLogin(string Username);
    }
}