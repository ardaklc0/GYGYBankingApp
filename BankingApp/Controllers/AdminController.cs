using BankingApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ITransactionService transactionService;
        private readonly IUserService userService;
        private readonly IAccountService accountService;
        private readonly ICustomerService customerService;
        public AdminController(ITransactionService transactionService, IAccountService accountService, IUserService userService, ICustomerService customerService)
        {
            this.transactionService = transactionService;
            this.accountService = accountService;
            this.userService = userService;
            this.customerService = customerService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AccountIndex()
        {
            var accounts = await accountService.GetAccountDisplayResponse();
            return View(accounts);
        }

        public async Task<IActionResult> CustomerIndex()
        {
            var customers = await customerService.GetCustomerDisplayResponse();
            return View(customers);
        }    

        public async Task<IActionResult> TransactionIndex()
        {
            var transactions = await transactionService.GetTransactionDisplayResponse();
            return View(transactions);
        }

        public async Task<IActionResult> UserIndex()
        {
            var users = await userService.GetUsersAsync();
            return View(users);
        }
    }
}
