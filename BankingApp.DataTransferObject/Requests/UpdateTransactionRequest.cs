using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.DataTransferObject.Requests
{
    public class UpdateTransactionRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string? Description { get; set; }
        public int AccountId { get; set; }
        public int CustomerId { get; set; }

    }
}
