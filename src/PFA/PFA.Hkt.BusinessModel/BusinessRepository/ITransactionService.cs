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
        beTransaction GetTransactionById(Guid transId);
        IEnumerable<beTransaction> GetAllTransaction(Guid UserID);
        IEnumerable<beTransaction> GetAllTransaction();
        Guid CreateTransaction(beTransaction transEntity);
        bool UpdateTransaction(Guid transId, beTransaction transEntity);
        bool DeleteTransaction(Guid transId);

    }
}
