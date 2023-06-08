using Azure.Core;
using BankingApp.DataTransferObject.Requests;
using BankingApp.DataTransferObject.Responses.User;
using BankingApp.Entities;
using BankingApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;
        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task CreateUserAsync(CreateNewUserRequest request)
        {
            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                Role = request.Role,
                UserName = request.UserName
            };
            await repository.CreateAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<UserDisplayResponse> GetUserAsync(int id)
        {
            var user = await repository.GetByIdAsync(id);
            var response = new UserDisplayResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role,
                UserName = user.UserName
            };
            return response;
        }

        public async Task<UpdateUserRequest> GetUserForUpdateAsync(int id)
        {
            var user = await repository.GetByIdAsync(id);
            var response = new UpdateUserRequest
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role,
                UserName = user.UserName
            };
            return response;
        }

        public async Task<IEnumerable<UserDisplayResponse>> GetUsersAsync()
        {
            var users = await repository.GetAllAsync();
            var responses = users.Select(user => new UserDisplayResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role,
                UserName = user.UserName
            });
            return responses;
        }

        public async Task UpdateUserAsync(UpdateUserRequest request)
        {
            var updatedUser = new User
            {
                Id = request.Id,
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                Role = request.Role,
                UserName = request.UserName
            };
            await repository.UpdateAsync(updatedUser);
        }

        public User ValidateUser(string username, string password)
        {
            var users = repository.GetAll();
            return users.SingleOrDefault(u => u.UserName == username && u.Password == password);
        }

        public async Task<User> ValidateUserAsync(string username, string password)
        {
            var users = await repository.GetAllAsync();
            return users.SingleOrDefault(u => u.UserName == username && u.Password == password);
        }
    }
}
