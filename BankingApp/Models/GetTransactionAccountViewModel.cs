using BankingApp.DataTransferObject.Responses.Account;
using BankingApp.DataTransferObject.Responses.Transaction;
using BankingApp.Entities;

namespace BankingApp.Models
{
    public class GetTransactionAccountViewModel
    {
        public IEnumerable<TransactionDisplayResponse>? Transactions { get; set; }
        public IEnumerable<AccountDisplayResponse>? Accounts { get; set; }
    }
}
