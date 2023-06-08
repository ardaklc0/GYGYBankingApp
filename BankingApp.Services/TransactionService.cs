using AutoMapper;
using BankingApp.DataTransferObject.Requests;
using BankingApp.DataTransferObject.Responses.Transaction;
using BankingApp.Entities;
using BankingApp.Infrastructure.Repositories;
using BankingApp.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Transaction = BankingApp.Entities.Transaction;

namespace BankingApp.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository repository;
        private readonly IMapper mapper;
        public TransactionService(ITransactionRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public void CreateTransaction(CreateNewTransactionRequest request)
        {
            var transaction = new Transaction
            {
                Name = request.Name,
                Amount = request.Amount,
                CreationDate = request.CreationDate,
                AccountId = request.AccountId,
                Description = request.Description,
            };
            repository.Create(transaction);
        }

        public async Task CreateTransactionAsync(CreateNewTransactionRequest request)
        {
            var transaction = new Transaction
            {
                Name = request.Name,
                Amount = request.Amount,
                CustomerId = request.CustomerId,
                CreationDate = request.CreationDate,
                AccountId = request.AccountId,
                Description = request.Description,
            };
            await repository.CreateAsync(transaction);
        }

        public async Task<TransactionDisplayResponse> GetTransactionAsync(int id)
        {
            var transaction = await repository.GetByIdAsync(id);
            var response = new TransactionDisplayResponse
            {
                Id = transaction.Id,
                Amount = transaction.Amount,
                CreationDate = transaction.CreationDate,
                CustomerId = transaction.CustomerId,
                Description = transaction.Description,
                Name = transaction.Name,
                AccountId = transaction.AccountId
            };
            return response;
        }

        public async Task<IEnumerable<TransactionDisplayResponse>> GetTransactionDisplayResponseWithRespectToCustomer(int customerId)
        {
            var transactions = await repository.GetAllAsync();
            var responses = transactions.Select(transaction => new TransactionDisplayResponse
            {
                Id = transaction.Id,
                Amount = transaction.Amount,
                CreationDate = transaction.CreationDate,
                CustomerId = transaction.CustomerId,
                Description = transaction.Description,
                Name = transaction.Name,
                AccountId = transaction.AccountId
            }).Where(account => account.CustomerId == customerId);
            return responses;   
        }

        public async Task DeleteTransaction(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task UpdateTransaction(UpdateTransactionRequest entity)
        {

            var updatedTransaction = new Transaction
            {
                Id = entity.Id,
                Name = entity.Name,
                Amount = entity.Amount,
                Description = entity.Description,
                AccountId = entity.AccountId,
                CreationDate = entity.CreationDate,
                CustomerId = entity.CustomerId,
            };
            await repository.UpdateAsync(updatedTransaction);       
        }

        public async Task<int> GetTransactionNumberWithRespectToAccount(int accountId)
        {
            var transactionsRequest = await repository.GetAllAsync();
            var transactions = transactionsRequest.Where(transaction => transaction.AccountId == accountId);
            var transactionCount = transactions.Count();
            return transactionCount;
        }

        public async Task<UpdateTransactionRequest> GetTransactionForUpdateAsync(int id)
        {
            var transaction = await repository.GetByIdAsync(id);
            var response = new UpdateTransactionRequest
            {
                Id = id,
                Amount = transaction.Amount,
                CreationDate = transaction.CreationDate,
                CustomerId = transaction.CustomerId,
                Description = transaction.Description,
                Name = transaction.Name,
                AccountId = transaction.AccountId
            };
            return response;
        }

        public async Task<IEnumerable<TransactionDisplayResponse>> GetTransactionDisplayResponse()
        {
            var transactions = await repository.GetAllAsync();
            var responses = transactions.Select(transaction => new TransactionDisplayResponse
            {
                Id = transaction.Id,
                Amount = transaction.Amount,
                CreationDate = transaction.CreationDate,
                CustomerId = transaction.CustomerId,
                Description = transaction.Description,
                Name = transaction.Name,
                AccountId = transaction.AccountId
            });
            return responses;
        }
    }
}
