using BankingApp.DataTransferObject.Requests;
using BankingApp.DataTransferObject.Responses.Transaction;


namespace BankingApp.Services
{
    public interface ITransactionService
    {
        Task<TransactionDisplayResponse> GetTransactionAsync(int id);
        Task<IEnumerable<TransactionDisplayResponse>> GetTransactionDisplayResponseWithRespectToCustomer(int customerId);
        Task<IEnumerable<TransactionDisplayResponse>> GetTransactionDisplayResponse();
        Task<UpdateTransactionRequest> GetTransactionForUpdateAsync(int id);
        Task CreateTransactionAsync(CreateNewTransactionRequest request);
        void CreateTransaction(CreateNewTransactionRequest request);
        Task DeleteTransaction(int id);
        Task UpdateTransaction(UpdateTransactionRequest entity);
        Task<int> GetTransactionNumberWithRespectToAccount(int accountId);
    }
}
