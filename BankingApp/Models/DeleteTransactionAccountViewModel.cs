using BankingApp.DataTransferObject.Responses.Account;
using BankingApp.DataTransferObject.Responses.Transaction;

namespace BankingApp.Models
{
    public class DeleteTransactionAccountViewModel
    {
        public TransactionDisplayResponse Transaction { get; set; }
        public AccountDisplayResponse Account { get; set; }
    }
}
