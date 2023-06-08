using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Entities
{
    public class Transaction : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string? Description { get; set; }
        public Customer? Customer { get; set; }
        public int CustomerId { get; set; }
        public Account? Account { get; set; }
        public int AccountId { get; set; }

    }
}
