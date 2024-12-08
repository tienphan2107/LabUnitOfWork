using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IBankAccountRepository BankAccountRepository { get; }

        Task<int> SaveChangesAsync();
        Task RollBackChangesAsync();
    }
}
