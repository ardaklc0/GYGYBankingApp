using BankingApp.DataTransferObject.Requests;
using BankingApp.DataTransferObject.Responses.Customer;
using BankingApp.Models;
using BankingApp.Services;
using BankingApp.Services.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Controllers
{
    [Authorize(Roles = "Admin, Client")]
    public class AccountController : Controller
    {

        private readonly ITransactionService transactionService;
        private readonly IUserService userService;
        private readonly IAccountService accountService;
        private readonly ICustomerService customerService;
        public AccountController(ITransactionService transactionService, IAccountService accountService, IUserService userService, ICustomerService customerService)
        {
            this.transactionService = transactionService;
            this.accountService = accountService;
            this.userService = userService;
            this.customerService = customerService;
        }
        public async Task<IActionResult> Index()
        {
            var userId = User.GetCurrentUserId();
            var customerId = customerService.GetCustomerWithRespectToUser(userId).Id;
            var accountCollection = await accountService.GetAccountDisplayResponseWithRespectToCustomer(customerId);
            var accountViewModel = new GetAccountViewModel
            {
                Accounts = accountCollection,
            };
            return View(accountViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNewAccountRequest request)
        {
            if (ModelState.IsValid)
            {
                var userId = User.GetCurrentUserId();
                var customerId = customerService.GetCustomerWithRespectToUser(userId).Id;
                request.CustomerId = customerId;
                await accountService.CreateAccountAsync(request);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var existingAccount = await accountService.GetAccount(id);
            var accountViewModel = new DeleteAccountViewModel
            {
                Account = existingAccount
            };
            ViewBag.TransactionNumber = transactionService.GetTransactionNumberWithRespectToAccount(id);
            return View(accountViewModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await accountService.DeleteAccount(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var existingAccount = await accountService.GetAccount(id);
            var updateAccount = new UpdateAccountRequest
            {
                Id = existingAccount.Id,
                Name = existingAccount.Name,
                Amount = existingAccount.Amount,
                CreationDate = existingAccount.CreationDate,
                CustomerId = existingAccount.CustomerId
            };
            return View(updateAccount);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateAccountRequest entity)
        {
            if (ModelState.IsValid)
            {
                var userId = User.GetCurrentUserId();
                var customer = customerService.GetCustomerWithRespectToUser(userId);
                entity.CustomerId = customer.Id;
                await accountService.UpdateAccount(entity);
                return RedirectToAction("Index");
            }
            return View(entity);
        }


        //private int GetUserId()
        //{
        //    return int.Parse(User.Claims.ToList()[3].Value);
        //}
        //private CustomerDisplayResponse? GetCustomerWithRespectToUser()
        //{
        //    int userId = GetUserId();
        //    return customerService.GetCustomers().FirstOrDefault(customer => customer.UserId == userId);
        //}
    }
}
