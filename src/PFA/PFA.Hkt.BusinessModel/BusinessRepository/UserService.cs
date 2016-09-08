using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using DataModel;
using AutoMapper;

namespace BusinessModel
{
    class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public beUser GetAccountById(Guid userId)
        {
            var user = _unitOfWork.UserRepository.GetById(userId);
            if (user != null)
            {
                Mapper.CreateMap<User, beUser>();

                var userModel = Mapper.Map<User, beUser>(user);
                return userModel;
            }
            return null;
        }

        public IEnumerable<beUser> GetAllUsers()
        {
            var users = _unitOfWork.UserRepository.GetAll().ToList();
            if (users != null)
            {
                Mapper.CreateMap<User, beUser>();

                var userModel = Mapper.Map<List<User>, List<beUser>>(users);
                return userModel;
            }
            return null;
        }

        public Guid CreateUser(beUser userEntity)
        {
            using (var scope = new TransactionScope())
            {
                var user = new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = userEntity.FirstName,
                    LastName = userEntity.LastName,
                    Email = userEntity.Email,
                    Password = userEntity.Password,
                    PasswordSalt = userEntity.PasswordSalt,
                    CurrencyId = userEntity.CurrencyId,
                    PrimaryNumber = userEntity.PrimaryNumber,
                    UserName = userEntity.UserName,
                    IsActive = true,
                    CreatedBy = userEntity.CreatedBy,
                    CreatedOn = DateTime.Now,
                    ModifiedBy = userEntity.ModifiedBy,
                    ModifiedOn = userEntity.ModifiedOn,
                };
                _unitOfWork.UserRepository.Insert(user);
                _unitOfWork.Save();
                scope.Complete();
                return user.Id;
            }
        }

        public bool UpdateUser(Guid userId, beUser userEntity)
        {
            var success = false;
            if (userEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var user = _unitOfWork.UserRepository.GetById(userId);
                    if (user != null)
                    {
                        user.FirstName = userEntity.FirstName;

                        user.LastName = userEntity.LastName;
                        user.Email = userEntity.Email;


                        _unitOfWork.UserRepository.Update(user);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public bool DeleteUser(Guid userId)
        {
            var success = false;
            if (userId != null)
            {
                using (var scope = new TransactionScope())
                {
                    var employee = _unitOfWork.UserRepository.GetById(userId);
                    {
                        _unitOfWork.UserRepository.Delete(employee);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public bool IsValid(string userName, string password)
        {
            User user = _unitOfWork.UserRepository.GetFirst(u => u.UserName == userName);
            if (user == null)
                return false;
            if (user.Password == password)
                return true;
            else
                return false;
        }

        public IEnumerable<beCurrency> GetAllCurrency()
        {
            var currency = _unitOfWork.CurrencyRepository.GetAll().ToList();
            if (currency != null)
            {
                Mapper.CreateMap<Currency, beCurrency>();

                var currencyModel = Mapper.Map<List<Currency>, List<beCurrency>>(currency);
                return currencyModel;
            }
            return null;
        }

    }
}
