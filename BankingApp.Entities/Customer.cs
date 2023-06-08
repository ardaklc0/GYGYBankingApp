using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Entities
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int Age { get; set; }
        public string? Location { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public User User { get; set; }
        public int UserId { get; set; }
        public List<Account>? Accounts { get; set; }
        
    }
}
