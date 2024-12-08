using Application.IServices;
using Domain.Entities;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BankAccountService(IUnitOfWork unitOfWork) : IBankAccountService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<BankAccount> Add(BankAccount bankAccount)
        {
            bankAccount.User = await _unitOfWork.UserRepository.GetById(bankAccount.Id);
            var newBankAccount = await _unitOfWork.BankAccountRepository.Add(bankAccount);
            await _unitOfWork.SaveChangesAsync();
            return newBankAccount;
        }

        public async Task Delete(int id)
        {
            var existingBankAccount = await _unitOfWork.BankAccountRepository.GetById(id)
                ?? throw new Exception("Not Found");

            _unitOfWork.BankAccountRepository.Delete(existingBankAccount);
            await _unitOfWork.SaveChangesAsync(); // Đợi phương thức SaveChangesAsync hoàn thành
        }


        public Task<BankAccount> GetById(int id)
        {
            return _unitOfWork.BankAccountRepository.GetById(id) ?? throw new Exception("Not Found");
        }

        public List<BankAccount> GetByUserId(int userId)
        {
            return _unitOfWork.BankAccountRepository.GetByUserId(userId) ?? throw new Exception("Not Found");
        }

        public Task<IList<BankAccount>> ListAll()
        {
            return _unitOfWork.BankAccountRepository.ListAll();
        }

        public async Task<BankAccount> Update(int id, BankAccount bankAccount)
        {
            var bankAccountUpdate = await _unitOfWork.BankAccountRepository.GetById(id)
                ?? throw new Exception("Not Found");
            bankAccountUpdate.AccountName = bankAccount.AccountName;
            bankAccountUpdate.Balance = bankAccount.Balance;
            _unitOfWork.BankAccountRepository.Update(bankAccountUpdate);
            await _unitOfWork.SaveChangesAsync(); // Đợi phương thức SaveChangesAsync hoàn thành
            return bankAccount;
        }

    }
}
