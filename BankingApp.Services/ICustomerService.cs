using BankingApp.DataTransferObject.Requests;
using BankingApp.DataTransferObject.Responses.Account;
using BankingApp.DataTransferObject.Responses.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Services
{
    public interface ICustomerService
    {
        Task<CustomerDisplayResponse> GetCustomerAsync(int id);
        Task<IEnumerable<CustomerDisplayResponse>> GetCustomerDisplayResponse();
        Task<CustomerDisplayResponse> GetCustomerWithRespectToUser(int userId);
        Task<int> GetCustomerIdWithRespectToUser(int userId);
        Task CreateCustomerAsync(CreateNewCustomerRequest request);
        Task DeleteCustomer(int id);
        Task UpdateCustomer(UpdateCustomerRequest entity);
    }
}
