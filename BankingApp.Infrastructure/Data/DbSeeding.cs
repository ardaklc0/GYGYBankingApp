using BankingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Infrastructure.Data
{
    public static class DbSeeding
    {
        public static void SeedDatabase(BankingDbContext dbContext)
        {
            seedUserIfNotExist(dbContext);
            seedCustomerIfNotExist(dbContext);
            seedAccountIfNotExist(dbContext);
            seedTransactionIfNotExist(dbContext);
        }

        private static void seedUserIfNotExist(BankingDbContext dbContext)
        {
            if (!dbContext.Users.Any())
            {
                var users = new List<User>
                {
                    new() { Email = "ardaklc0@gmail.com", Password = "12345", Role = "Admin", UserName = "ardaklc", Name = "Arda" },
                    new() { Email = "turkayurk0@gmail.com", Password = "12345", Role = "Client", UserName = "turkyurkmz", Name = "Türkay"},
                    new() { Email = "berfinnur0@gmail.com", Password = "12345", Role = "Client", UserName = "berfnnur", Name = "Berfin" }
                };
                dbContext.Users.AddRange(users);
                dbContext.SaveChanges();
            }
        }

        private static void seedCustomerIfNotExist(BankingDbContext dbContext)
        {
            if (!dbContext.Customers.Any())
            {
                var customers = new List<Customer>
                {
                    new() {  Name = "Arda", Surname = "Kılıç", Age = 22, Location = "Üsküdar", UserId = 1},
                    new() {  Name = "Türkay", Surname = "Ürkmez", Age = 35, Location = "Eskişehir", UserId = 2},
                    new() {  Name = "Berfin Nur", Surname = "Uğur", Age = 22, Location = "Altunizade", UserId = 3},
                };
                dbContext.Customers.AddRange(customers);
                dbContext.SaveChanges();
            }
        }

        private static void seedAccountIfNotExist(BankingDbContext dbContext)
        {
            if (!dbContext.Accounts.Any())
            {
                var accounts = new List<Account>
                {
                    new() {  Name = "Savings Account", Amount = 3450.12M, CustomerId = 1},
                    new() {  Name = "Cash Account", Amount = 1450.12M, CustomerId = 1},
                    new() {  Name = "Current Account", Amount = 2340.32M, CustomerId = 2},
                    new() {  Name = "Investment Account", Amount = 1250.72M, CustomerId = 3},
                };
                dbContext.Accounts.AddRange(accounts);
                dbContext.SaveChanges();
            }
        }

        private static void seedTransactionIfNotExist(BankingDbContext dbContext)
        {
            if (!dbContext.Transactions.Any())
            {
                var transactions = new List<Transaction>
                {
                    new() { CustomerId = 1, Name = "Grocery Shopping", Amount = 123.42M, Description = "Transaction completed succesfully", AccountId = 1},
                    new() { CustomerId = 1, Name = "Gas Shopping", Amount = 249.99M, Description = "Transaction completed succesfully", AccountId = 2},
                    new() { CustomerId = 3, Name = "Lego Shopping", Amount = 459.95M, Description = "Transaction completed succesfully", AccountId = 3},
                    new() { CustomerId = 3, Name = "Lego Shopping", Amount = 459.95M, Description = "Transaction completed succesfully", AccountId = 4},
                };
                dbContext.Transactions.AddRange(transactions);
                dbContext.SaveChanges();
            }
        }
    }
}
