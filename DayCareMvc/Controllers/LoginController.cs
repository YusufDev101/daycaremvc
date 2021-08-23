using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DayCareMvc.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login()
        {
            try
            {
                var username = "Yusuf Khan";
                var password = "password";


                HttpContext.Session.SetString("_Name", username);
                HttpContext.Session.SetInt32("_Age", 24);

                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, username)
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                AuthenticationProperties authenticationProperties = new()
                {
                    IsPersistent = false,
                    AllowRefresh = true,
                    Items = { { "username", username} }
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authenticationProperties);

                return RedirectToActionPermanent("Index", "Home");
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
