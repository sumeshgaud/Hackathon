using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
    public interface ICommonService
    {

        beCategory GetCategoryById(Guid categoryId);
        IEnumerable<beCategory> GetAllCategory(Guid userId);
        Guid CreateCategory(beCategory categoryEntity);
        bool UpdateCategory(Guid categoryId, beCategory categoryEntity);
        bool DeleteCategory(Guid categoryId);
    }
}
