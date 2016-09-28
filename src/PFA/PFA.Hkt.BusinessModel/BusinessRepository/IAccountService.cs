using BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
    public interface IAccountService
    {
        beAccount GetAccountById(int accountId);
        IEnumerable<beAccount> GetAllAccounts();
        int CreateAccount(beAccount accountEntity);
        bool UpdateAccount(int accountId, beAccount accountEntity);
        bool DeleteAccount(int accountId);
    }
}
