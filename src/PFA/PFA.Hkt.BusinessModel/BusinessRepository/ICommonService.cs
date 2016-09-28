using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
    public interface ICommonService
    {

        beCategory GetCategoryById(int categoryId);
        IEnumerable<beCategory> GetAllCategory(int userId);
        int CreateCategory(beCategory categoryEntity);
        bool UpdateCategory(int categoryId, beCategory categoryEntity);
        bool DeleteCategory(int categoryId);
    }
}
