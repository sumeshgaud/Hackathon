using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using DataModel;
using AutoMapper;

namespace BusinessModel
{
   public class BudgetService : IBudgetService
    {
        private IUnitOfWork _unitOfWork;

        public BudgetService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region "Budget Methods"
        public beBudget GetBudgetById(int budgetId)
        {
            var budget = _unitOfWork.BudgetRepository.GetById(budgetId);
            if (budget != null)
            {
                Mapper.CreateMap<Budget, beBudget>();

                var budgetModel = Mapper.Map<Budget, beBudget>(budget);
                return budgetModel;
            }
            return null;
        }

        public IEnumerable<beBudget> GetAllBudget()
        {
            var budget = _unitOfWork.BudgetRepository.GetAll().ToList();
            if (budget != null)
            {
                Mapper.CreateMap<Budget, beBudget>();

                var budgetModel = Mapper.Map<List<Budget>, List<beBudget>>(budget);
                return budgetModel;
            }
            return null;
        }

        public int CreateBudget(beBudget budgetEntity)
        {
            using (var scope = new TransactionScope())
            {
                var budget = new Budget
                {
                    Id = new int(),
                    UserId = budgetEntity.UserId,
                    Month = budgetEntity.Month,
                    Year = budgetEntity.Year,
                    IsRecuring = budgetEntity.IsRecuring,
                    Type = budgetEntity.Type,
                    CreatedBy = budgetEntity.CreatedBy,
                    CreatedOn = DateTime.Now,
                    ModifiedBy = budgetEntity.ModifiedBy,
                    ModifiedOn = budgetEntity.ModifiedOn,
                };
                _unitOfWork.BudgetRepository.Insert(budget);
                _unitOfWork.Save();
                scope.Complete();
                return budget.Id;
            }
        }

        public bool UpdateBudget(int budgetId, beBudget budgetEntity)
        {
            var success = false;
            if (budgetEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var budget = _unitOfWork.BudgetRepository.GetById(budgetId);
                    if (budget != null)
                    {
                        budget.Month = budgetEntity.Month;
                        budget.Year = budgetEntity.Year;
                        _unitOfWork.BudgetRepository.Update(budget);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public bool DeleteBudget(int budgetId)
        {
            var success = false;
            if (budgetId != null)
            {
                using (var scope = new TransactionScope())
                {
                    var budgetDetail = GetAllBudgetDetailByBudgetId(budgetId);
                    foreach (var item in budgetDetail)
                    {
                        this.DeleteBudgetDetail(item.Id);
                    }

                    var budget = _unitOfWork.BudgetRepository.GetById(budgetId);
                    {
                        _unitOfWork.BudgetRepository.Delete(budget);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        #endregion

        #region "Budget Detail Methods"
        public beBudgetDetail GetBudgetDtialById(int budgetDetailId)
        {
            var budgetDetail = _unitOfWork.BudgetDetailRepository.GetById(budgetDetailId);
            if (budgetDetail != null)
            {
                Mapper.CreateMap<BudgetDetail, beBudgetDetail>();

                var budgetDetailModel = Mapper.Map<BudgetDetail, beBudgetDetail>(budgetDetail);
                return budgetDetailModel;
            }
            return null;
        }

        public IEnumerable<beBudgetDetail> GetAllBudgetDetail()
        {
            var budgetDetail = _unitOfWork.BudgetDetailRepository.GetAll().ToList();
            if (budgetDetail != null)
            {
                Mapper.CreateMap<BudgetDetail, beBudgetDetail>();

                var budgetDetailModel = Mapper.Map<List<BudgetDetail>, List<beBudgetDetail>>(budgetDetail);
                return budgetDetailModel;
            }
            return null;
        }

        public IEnumerable<beBudgetDetail> GetAllBudgetDetailByBudgetId(int budgetId)
        {
            var budgetDetail = _unitOfWork.BudgetDetailRepository.GetMany(b => b.BudgetId == budgetId).ToList();

            if (budgetDetail != null)
            {
                Mapper.CreateMap<BudgetDetail, beBudgetDetail>();

                var budgetDetailModel = Mapper.Map<List<BudgetDetail>, List<beBudgetDetail>>(budgetDetail);
                return budgetDetailModel;
            }
            return null;
        }

        public int CreateBudgetDetail(beBudgetDetail budgetDetailEntity)
        {
            using (var scope = new TransactionScope())
            {
                var budgetDetail = new BudgetDetail
                {
                    Id = new int(),
                    BudgetId = budgetDetailEntity.BudgetId,
                    Amount = budgetDetailEntity.Amount,
                    CategoryId = budgetDetailEntity.CategoryId,
                    CreatedBy = budgetDetailEntity.CreatedBy,
                    CreatedOn = DateTime.Now,
                    ModifiedBy = budgetDetailEntity.ModifiedBy,
                    ModifiedOn = budgetDetailEntity.ModifiedOn,
                };
                _unitOfWork.BudgetDetailRepository.Insert(budgetDetail);
                _unitOfWork.Save();
                scope.Complete();
                return budgetDetail.Id;
            }
        }

        public bool UpdateBudgetDetail(int budgetDetailId, beBudgetDetail budgetDetailEntity)
        {
            var success = false;
            if (budgetDetailEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var budgetDetail = _unitOfWork.BudgetDetailRepository.GetById(budgetDetailId);
                    if (budgetDetail != null)
                    {
                        budgetDetail.CategoryId = budgetDetailEntity.CategoryId;
                        budgetDetail.Amount = budgetDetailEntity.Amount;
                        _unitOfWork.BudgetDetailRepository.Update(budgetDetail);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public bool DeleteBudgetDetail(int budgetDetailId)
        {
            var success = false;
            if (budgetDetailId != null)
            {
                using (var scope = new TransactionScope())
                {
                    var budgetDetail = _unitOfWork.BudgetDetailRepository.GetById(budgetDetailId);
                    {
                        _unitOfWork.BudgetDetailRepository.Delete(budgetDetail);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
        #endregion
    }
}
