using BankingApp.DataTransferObject.Requests;
using BankingApp.Models;
using BankingApp.Services;
using BankingApp.Services.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace BankingApp.Controllers
{
    [Authorize(Roles = "Admin, Client")]

    public class UserController : Controller
    {
        private IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            int userId = User.GetCurrentUserId();
            var currentUser = await userService.GetUserAsync(userId);
            return View(currentUser);
        }

        public IActionResult Login(string? RequestedPage)
        {
            ViewBag.ReturnUrl = RequestedPage;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel userLogin, string? RequestedPage)
        {
            if (ModelState.IsValid)
            {
                var user = await userService.ValidateUserAsync(userLogin.UserName, userLogin.Password);
                if (user != null)
                {
                    Claim[] claims = new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Email,user.Email),
                        new Claim(ClaimTypes.Role,user.Role),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                    };
                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(principal);
                    if (!string.IsNullOrEmpty(RequestedPage) && Url.IsLocalUrl(RequestedPage))
                    {
                        return Redirect(RequestedPage);
                    }
                    return Redirect("/");
                }
                ModelState.AddModelError("login", "Username or password is wrong");
            }
            return View();   
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Create(CreateNewUserRequest request)
        {
            if (ModelState.IsValid)
            {
                await userService.CreateUserAsync(request);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var existingUser = userService.GetUserAsync(id);
            return View(existingUser);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await userService.DeleteUserAsync(id);
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Edit(int id)
        {
            var existingUser = await userService.GetUserForUpdateAsync(id);
            return View(existingUser);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UpdateUserRequest request)
        {
            if (ModelState.IsValid)
            {
                await userService.UpdateUserAsync(request);
                return RedirectToAction("Index");

            }
            return View();
        }

        public async Task<IActionResult> Logout() 
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
       
    }
}
