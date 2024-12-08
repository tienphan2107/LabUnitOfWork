using Application.IServices;
using Domain.Entities;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService(IUnitOfWork unitOfWork) : IUserService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<User> AddUser(User user)
        {
            var newUser = await _unitOfWork.UserRepository.Add(user);
            await _unitOfWork.SaveChangesAsync();
            return newUser;
        }

        public Task<int> CheckUser(string username, string password)
        {
            int result = _unitOfWork.UserRepository.CheckUser(username, password);
            return Task.FromResult(result);
        }

        public Task<User> DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByIdUser(int id)
        {
            return await _unitOfWork.UserRepository.GetById(id);
        }

        public Task<IList<User>> ListAllUser()
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
