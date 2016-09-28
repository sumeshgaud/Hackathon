using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
    public interface IUserService
    {
        beUser GetAccountById(int userId);
        IEnumerable<beUser> GetAllUsers();
        int CreateUser(beUser userEntity);
        bool UpdateUser(int userId, beUser userEntity);
        bool DeleteUser(int userId);
        bool IsValid(string userName, string password);
        IEnumerable<beCurrency> GetAllCurrency();
    }
}
