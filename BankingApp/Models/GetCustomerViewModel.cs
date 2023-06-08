using BankingApp.DataTransferObject.Responses.Account;
using BankingApp.DataTransferObject.Responses.Customer;

namespace BankingApp.Models
{
    public class GetCustomerViewModel
    {
        public CustomerDisplayResponse Customer { get; set; }
        public IEnumerable<AccountDisplayResponse> Accounts { get; set; }
    }
}
