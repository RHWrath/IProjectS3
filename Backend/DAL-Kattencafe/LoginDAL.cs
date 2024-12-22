using Logic.Models;
using Logic.Interfaces;

namespace DAL
{
    public class LoginDAL : ILoginDAL
    {
        private DatabaseContext _dbContext;

        public LoginDAL(DatabaseContext DBC)
        {
            _dbContext = DBC;     
        }

        

        public UserAcountModel GetUserLogin(string Username)
        {
            return _dbContext.UserAcounts.FirstOrDefault(x => x.UserName == Username);
        } 


        
    }
}
