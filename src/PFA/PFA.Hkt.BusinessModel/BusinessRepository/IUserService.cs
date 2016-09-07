using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
    public interface IUserService
    {
        beUser GetAccountById(Guid userId);
        IEnumerable<beUser> GetAllUsers();
        Guid CreateUser(beUser userEntity);
        bool UpdateUser(Guid userId, beUser userEntity);
        bool DeleteUser(Guid userId);
    }
}
