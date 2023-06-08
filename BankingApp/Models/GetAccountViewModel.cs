using BankingApp.DataTransferObject.Responses.Account;

namespace BankingApp.Models
{
    public class GetAccountViewModel
    {
        public IEnumerable<AccountDisplayResponse> Accounts { get; set; }

    }
}
