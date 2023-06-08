using BankingApp.DataTransferObject.Requests;
using BankingApp.DataTransferObject.Responses.Account;


namespace BankingApp.Services
{
    public interface IAccountService
    {
        Task<AccountDisplayResponse> GetAccount(int id);
        Task<IEnumerable<AccountDisplayResponse>> GetAccountDisplayResponseWithRespectToCustomer(int customerId);
        Task<IEnumerable<AccountDisplayResponse>> GetAccountDisplayResponse();
        Task CreateAccountAsync(CreateNewAccountRequest request);
        Task DeleteAccount(int id);
        Task UpdateAccount(UpdateAccountRequest request);
        Task UpdateAccountDueToTransaction(AccountDisplayResponse request, decimal amount);
    }
}
