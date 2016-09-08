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
        beAccount GetAccountById(Guid accountId);
        IEnumerable<beAccount> GetAllAccounts();
        Guid CreateAccount(beAccount accountEntity);
        bool UpdateAccount(Guid accountId, beAccount accountEntity);
        bool DeleteAccount(Guid accountId);
    }
}
