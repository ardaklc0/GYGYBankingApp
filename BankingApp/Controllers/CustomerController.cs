using BankingApp.DataTransferObject.Requests;
using BankingApp.Models;
using BankingApp.Services;
using BankingApp.Services.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BankingApp.Controllers
{
    [Authorize(Roles = "Admin, Client")]

    public class CustomerController : Controller
    {
        private readonly ITransactionService transactionService;
        private readonly IUserService userService;
        private readonly IAccountService accountService;
        private readonly ICustomerService customerService;
        public CustomerController(ITransactionService transactionService, IAccountService accountService, IUserService userService, ICustomerService customerService)
        {
            this.transactionService = transactionService;
            this.accountService = accountService;
            this.userService = userService;
            this.customerService = customerService;
        }
        public async Task<IActionResult> Index()
        {
            var userId = User.GetCurrentUserId();
            var customer = await customerService.GetCustomerWithRespectToUser(userId);
            var accounts = await accountService.GetAccountDisplayResponseWithRespectToCustomer(customer.Id);
            var customerViewModel = new GetCustomerViewModel
            {
                Customer = customer,
                Accounts = accounts

            };
            return View(customerViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNewCustomerRequest request)
        {
            if (ModelState.IsValid)
            {
                var userId = User.GetCurrentUserId();
                request.UserId = userId;
                await customerService.CreateCustomerAsync(request);
                return RedirectToAction("Index");
            }
            return View();
        }
        
        public async Task<IActionResult> Delete(int id)
        {
            var existingCustomer = await customerService.GetCustomerAsync(id);
            var customerViewModel = new DeleteCustomerViewModel
            {
                Customer = existingCustomer
            };
            return View(customerViewModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await customerService.DeleteCustomer(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var existingCustomer = await customerService.GetCustomerAsync(id);
            var updateCustomer = new UpdateCustomerRequest
            {
                Id = existingCustomer.Id,
                Name = existingCustomer.Name,
                Surname = existingCustomer.Surname,
                Age = existingCustomer.Age,
                CreationDate = existingCustomer.CreationDate,
                Location = existingCustomer.Location,
                UserId = existingCustomer.UserId
            };
            return View(updateCustomer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateCustomerRequest entity)
        {
            if (ModelState.IsValid)
            {
                var userId = User.GetCurrentUserId();
                entity.UserId = userId;
                await customerService.UpdateCustomer(entity);
                return RedirectToAction("Index");
            }
            return View(entity);
        }
    }
}
