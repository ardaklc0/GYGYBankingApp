using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.DataTransferObject.Requests
{
    public class UpdateCustomerRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int Age { get; set; }
        public string? Location { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public int UserId { get; set; }
    }
}
