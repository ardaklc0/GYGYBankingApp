using AutoMapper;
using BankingApp.DataTransferObject.Requests;
using BankingApp.DataTransferObject.Responses.Account;
using BankingApp.Entities;
using BankingApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository repository;
        private readonly IMapper mapper;
        public AccountService(IAccountRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<AccountDisplayResponse>> GetAccountDisplayResponse()
        {
            var accounts = await repository.GetAllAsync();
            var responses = accounts.Select(account => new AccountDisplayResponse
            {
                Id = account.Id,
                Amount = account.Amount,
                CreationDate = account.CreationDate,
                CustomerId = account.CustomerId,
                Name = account.Name
            });
            return responses;
        }
        public async Task<IEnumerable<AccountDisplayResponse>> GetAccountDisplayResponseWithRespectToCustomer(int customerId)
        {
            var accounts = await repository.GetAllAsync();
            var responses = accounts.Select(account => new AccountDisplayResponse
            {
                Id = account.Id,
                Amount = account.Amount,
                CreationDate = account.CreationDate,
                CustomerId = account.CustomerId,
                Name = account.Name
            }).Where(account => account.CustomerId == customerId);
            return responses;
        }

        public async Task<AccountDisplayResponse> GetAccount(int id)
        {
            var account = await repository.GetByIdAsync(id);
            var response = new AccountDisplayResponse
            {
                Id = account.Id,
                Amount = account.Amount,
                CreationDate = account.CreationDate,
                CustomerId = account.CustomerId,
                Name = account.Name
            };
            return response;
        }

        public async Task CreateAccountAsync(CreateNewAccountRequest request)
        {
            var account = new Account
            {
                Name = request.Name,
                Amount = request.Amount,
                CreationDate = request.CreationDate,
                CustomerId = request.CustomerId,
            };
            await repository.CreateAsync(account);
        }

        public async Task DeleteAccount(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task UpdateAccount(UpdateAccountRequest request)
        {
            var updatedAccount = new Account
            {
                Id = request.Id,
                Name = request.Name,
                Amount = request.Amount,
                CreationDate = request.CreationDate,
                CustomerId = request.CustomerId,
            };
            await repository.UpdateAsync(updatedAccount);
        }

        public async Task UpdateAccountDueToTransaction(AccountDisplayResponse request, decimal amount)
        {
            var updatedAccount = new Account
            {
                Id = request.Id,
                Name = request.Name,
                Amount = request.Amount + amount,
                CreationDate = request.CreationDate,
                CustomerId = request.CustomerId,
            };
            await repository.UpdateAsync(updatedAccount);
        }
    }
}
