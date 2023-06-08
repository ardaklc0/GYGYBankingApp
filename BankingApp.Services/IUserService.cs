using BankingApp.DataTransferObject.Requests;
using BankingApp.DataTransferObject.Responses.User;
using BankingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Services
{
    public interface IUserService
    {
        Task<User> ValidateUserAsync(string username, string password);
        User ValidateUser(string username, string password);
        Task<UserDisplayResponse> GetUserAsync(int id);
        Task<UpdateUserRequest> GetUserForUpdateAsync(int id);
        Task<IEnumerable<UserDisplayResponse>> GetUsersAsync();
        Task CreateUserAsync(CreateNewUserRequest request);
        Task DeleteUserAsync(int id);
        Task UpdateUserAsync(UpdateUserRequest request);
    }
}