using BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
    public interface ITransactionService
    {
        beTransaction GetTransactionById(int transId);
        IEnumerable<beTransaction> GetAllTransaction(int UserID);
        IEnumerable<beTransaction> GetAllTransaction();
        int CreateTransaction(beTransaction transEntity);
        bool UpdateTransaction(int transId, beTransaction transEntity);
        bool DeleteTransaction(int transId);

    }
}
