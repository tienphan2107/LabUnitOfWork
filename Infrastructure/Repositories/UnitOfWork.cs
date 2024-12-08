using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly DBContext _dbContext;
        private readonly IDictionary<Type, dynamic> _repositories;
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IUserRepository _userRepository;

        public IBankAccountRepository BankAccountRepository => _bankAccountRepository;
        public IUserRepository UserRepository => _userRepository;

        public UnitOfWork(DBContext dbContext, IBankAccountRepository bankAccountRepository, IUserRepository userRepository)
        {
            _dbContext = dbContext;
            _repositories = new Dictionary<Type, dynamic>();
            _bankAccountRepository = bankAccountRepository;
            _userRepository = userRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async Task RollBackChangesAsync()
        {
            await _dbContext.Database.RollbackTransactionAsync();
        }
    }
}
