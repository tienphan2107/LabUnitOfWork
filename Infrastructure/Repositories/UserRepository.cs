using Domain.Entities;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : BaseRepositoryAsync<User>, IUserRepository
    {
        public UserRepository(DBContext dbContext) : base(dbContext)
        {
        }
        public int CheckUser(string username, string password)
        {
            var user = _dbContext.Users.Where(x => x.username == username && x.password == password).FirstOrDefault();
            if (user == null)
            {
                return -1;
            }
            return user.Id;
        }
    }
}
