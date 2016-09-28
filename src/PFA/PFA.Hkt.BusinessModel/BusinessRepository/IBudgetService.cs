using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
   public interface IBudgetService
    {
        beBudget GetBudgetById(int budgetId);
        IEnumerable<beBudget> GetAllBudget();
        int CreateBudget(beBudget budgetEntity);
        bool UpdateBudget(int budgetId, beBudget budgetEntity);
        bool DeleteBudget(int budgetId);

        #region "Budget Detail"
        beBudgetDetail GetBudgetDtialById(int budgetDetailId);
        IEnumerable<beBudgetDetail> GetAllBudgetDetail();
        int CreateBudgetDetail(beBudgetDetail budgetDetailEntity);
        bool UpdateBudgetDetail(int budgetDetailId, beBudgetDetail budgetDetailEntity);
        bool DeleteBudgetDetail(int budgetDetailId);
        IEnumerable<beBudgetDetail> GetAllBudgetDetailByBudgetId(int budgetId);
        #endregion
    }
}
