using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IBankAccountService
    {
        List<BankAccount> GetByUserId(int userId);

        Task<BankAccount> GetById(int id);

        Task<BankAccount> Add(BankAccount bankAccount);

        Task<IList<BankAccount>> ListAll();
        Task<BankAccount> Update(int id, BankAccount bankAccount);
        Task Delete(int id);


    }
}
