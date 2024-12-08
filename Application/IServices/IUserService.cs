using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IUserService
    {
        Task<int> CheckUser(string username, string password);

        Task<User> AddUser(User user);

        Task<User> UpdateUser(User user);

        Task<User> DeleteUser(User user);


        Task<IList<User>> ListAllUser();

        Task<User> GetByIdUser(int id);
    }
}
