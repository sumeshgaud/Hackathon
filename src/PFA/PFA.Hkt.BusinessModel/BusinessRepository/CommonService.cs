using AutoMapper;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BusinessModel
{
    public class CommonService : ICommonService
    {
        private IUnitOfWork _unitOfWork;

        public CommonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public beCategory GetCategoryById(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<beCategory> GetAllCategory(Guid userId)
        {

            var categoryList = _unitOfWork.CategoryRepository.GetAll().Where(x => x.UserId == userId).ToList();

            try
            {
                if (categoryList != null)
                {
                    Mapper.CreateMap<Category, beCategory>();

                    var userModel = Mapper.Map<List<Category>, List<beCategory>>(categoryList);
                    return userModel;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Guid CreateCategory(beCategory categoryEntity)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    var category = new Category
                    {
                        Id = new Guid(),
                        UserId = categoryEntity.UserId,
                        CategoryName = categoryEntity.CategoryName,
                        Type = categoryEntity.Type,
                        IsActive = categoryEntity.IsActive,
                        ParentCategoryId = categoryEntity.ParentCategoryId
                    };
                    _unitOfWork.CategoryRepository.Insert(category);
                    _unitOfWork.Save();
                    scope.Complete();
                    return category.Id;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
 
        public bool UpdateCategory(Guid categoryId, beCategory categoryEntity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCategory(Guid categoryId)
        {
            bool IsSuccess = false;
            try
            {

                if (categoryId != null)
                {
                    using (var scope = new TransactionScope())
                    {
                        var category = _unitOfWork.UserRepository.GetById(categoryId);
                        {
                            _unitOfWork.CategoryRepository.Delete(category);
                            _unitOfWork.Save();
                            scope.Complete();
                            IsSuccess = true;
                        }
                    }
                }
                return IsSuccess;
            }
            catch (Exception)
            {
                IsSuccess = false;
                throw;
            }

        }

    }
}
