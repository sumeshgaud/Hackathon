using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
   public interface IBudgetService
    {
        beBudget GetBudgetById(Guid budgetId);
        IEnumerable<beBudget> GetAllBudget();
        Guid CreateBudget(beBudget budgetEntity);
        bool UpdateBudget(Guid budgetId, beBudget budgetEntity);
        bool DeleteBudget(Guid budgetId);

        #region "Budget Detail"
        beBudgetDetail GetBudgetDtialById(Guid budgetDetailId);
        IEnumerable<beBudgetDetail> GetAllBudgetDetail();
        Guid CreateBudgetDetail(beBudgetDetail budgetDetailEntity);
        bool UpdateBudgetDetail(Guid budgetDetailId, beBudgetDetail budgetDetailEntity);
        bool DeleteBudgetDetail(Guid budgetDetailId);
        IEnumerable<beBudgetDetail> GetAllBudgetDetailByBudgetId(Guid budgetId);
        #endregion
    }
}
