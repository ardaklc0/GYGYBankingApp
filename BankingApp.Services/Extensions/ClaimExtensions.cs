using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Services.Extensions
{
    public static class ClaimExtensions
    {
        public static int GetCurrentUserId(this ClaimsPrincipal User)
        {
            return int.Parse(User.Claims.ToList()[3].Value);
        }
    }
}
