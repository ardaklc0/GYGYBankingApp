using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.DataTransferObject.Responses.Account
{
    public class AccountDisplayResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public int? CustomerId { get; set; }
    }
}
