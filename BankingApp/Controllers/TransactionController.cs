using BankingApp.DataTransferObject.Requests;
using BankingApp.Entities;
using BankingApp.Models;
using BankingApp.Services;
using BankingApp.Services.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BankingApp.Controllers
{
    [Authorize(Roles = "Admin, Client")]

    public class TransactionController : Controller
    {
        private readonly ITransactionService transactionService;
        private readonly IUserService userService;
        private readonly IAccountService accountService;
        private readonly ICustomerService customerService;
        public TransactionController(ITransactionService transactionService, IAccountService accountService, IUserService userService, ICustomerService customerService)
        {
            this.transactionService = transactionService;
            this.accountService = accountService;
            this.userService = userService;
            this.customerService = customerService;
        }

        public async Task<IActionResult> Index()
        {
            int userId = User.GetCurrentUserId();
            var customerId = await customerService.GetCustomerIdWithRespectToUser(userId);
            var transactionCollection = await transactionService.GetTransactionDisplayResponseWithRespectToCustomer(customerId);
            var accounts = await accountService.GetAccountDisplayResponseWithRespectToCustomer(customerId);
            var transactionViewModel = new GetTransactionAccountViewModel
            {
                Transactions = transactionCollection,
                Accounts = accounts
            };
            return View(transactionViewModel);
        }

        public IActionResult Create()
        {
            ViewBag.Accounts = GetAccountsForSelectList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNewTransactionRequest request)
        {
            if (ModelState.IsValid)
            {
                int userId = User.GetCurrentUserId();
                var customerId = await customerService.GetCustomerIdWithRespectToUser(userId);
                request.CustomerId = customerId;
                var account = await accountService.GetAccount(request.AccountId);
                if (account.Amount >= request.Amount)
                {
                    await transactionService.CreateTransactionAsync(request);
                    await accountService.UpdateAccountDueToTransaction(account, -request.Amount);
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction("InsufficientBalance");
            }
            ViewBag.Accounts = GetAccountsForSelectList();
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var existingTransaction = await transactionService.GetTransactionAsync(id);
            var existingAccount = await accountService.GetAccount(existingTransaction.AccountId);
            var transactionAccountViewModel = new DeleteTransactionAccountViewModel
            {
                Account = existingAccount,
                Transaction = existingTransaction
            };
            return View(transactionAccountViewModel);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var existingTransaction = await transactionService.GetTransactionAsync(id);
            var existingAccount = await accountService.GetAccount(existingTransaction.AccountId);
            await transactionService.DeleteTransaction(id);
            await accountService.UpdateAccountDueToTransaction(existingAccount, existingAccount.Amount);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var existingTransaction = await transactionService.GetTransactionForUpdateAsync(id);
            return View(existingTransaction);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, UpdateTransactionRequest entity)
        {
            if (ModelState.IsValid)
            {
                var existingTransaction = await transactionService.GetTransactionAsync(id);
                var account = await accountService.GetAccount(existingTransaction.AccountId);

                entity.CustomerId = existingTransaction.CustomerId;
                entity.AccountId = existingTransaction.AccountId;


                if (existingTransaction.Amount <= entity.Amount)
                {
                    await transactionService.UpdateTransaction(entity);
                    await accountService.UpdateAccountDueToTransaction(account, existingTransaction.Amount - entity.Amount);
                    return RedirectToAction("Index");
                }
                else if (existingTransaction.Amount > entity.Amount)
                {
                    await transactionService.UpdateTransaction(entity);
                    await accountService.UpdateAccountDueToTransaction(account, entity.Amount - existingTransaction.Amount);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("InsufficientBalance");
            }
            return View(entity);
        }
        public IActionResult InsufficientBalance()
        {
            return View();
        }
        private async Task<IEnumerable<SelectListItem>> GetAccountsForSelectList()
        {
            int userId = User.GetCurrentUserId();
            var customerId = customerService.GetCustomerWithRespectToUser(userId).Id;
            var accounts = await accountService.GetAccountDisplayResponseWithRespectToCustomer(customerId);
            var selectItemAccounts = accounts.Select(acc => new SelectListItem { Text = acc.Name, Value = acc.Id.ToString()}).ToList();
            return selectItemAccounts;
        }
    }
}
