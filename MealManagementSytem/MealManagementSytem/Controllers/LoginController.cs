using MealManagementSytem.Data;
using MealManagementSytem.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MealManagementSytem.Controllers
{


    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public  IActionResult Index(Member prm)
        {
            ClaimsIdentity identity = null;
            bool IsAuthenticated = false;
            var checkLogin = _context.Members.FirstOrDefault(e => e.MemberId == prm.MemberId && e.MemberPass == prm.MemberPass);
            if (checkLogin == null || checkLogin.ToString() == "")
            {
                ViewBag.error = "Your User Id or Password Is Incorrect!";
            }
            else
            {
                HttpContext.Session.SetString("UserId", prm.MemberId.ToString());
                identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, checkLogin.MemberId.ToString()),
                    new Claim(ClaimTypes.Role, checkLogin.MemberType)
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                IsAuthenticated = true;
                if(IsAuthenticated == true)
                {
                    var principle = new ClaimsPrincipal(identity);
                    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principle);
                    return RedirectToAction("Index", "Home");
                }
                
            }
            return View();
        }


    }

}
