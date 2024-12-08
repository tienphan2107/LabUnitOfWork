using Domain.Entities;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BankAccountRepository : BaseRepositoryAsync<BankAccount>, IBankAccountRepository
    {
        public BankAccountRepository(DBContext dbContext) : base(dbContext)
        {
        }
        public List<BankAccount> GetByUserId(int userId)
        {
            return _dbContext.BankAccounts.Where(x => x.UserId == userId).Include(x => x.User).ToList();
        }
    }
}
