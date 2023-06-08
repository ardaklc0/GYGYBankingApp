using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.DataTransferObject.Requests
{
    public class CreateNewAccountRequest
    {
        public string? Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public int? CustomerId { get; set; }
    }
}
