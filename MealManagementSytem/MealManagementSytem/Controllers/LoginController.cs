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
            try
            {
                var checkLogin = _context.Members.FirstOrDefault(e => e.MemberId == prm.MemberId && e.MemberPass == prm.MemberPass);
                if (checkLogin == null || checkLogin.ToString() == "")
                {
                    ViewBag.error = "Your User Id or Password Is Incorrect!";
                }
                else
                {
                    HttpContext.Session.SetString("UserId", prm.MemberId.ToString());
                    HttpContext.Session.SetString("UserType", checkLogin.MemberType);
                    var claims = new List<Claim>
                     {
                         new Claim(ClaimTypes.Role, checkLogin.MemberType)
                     };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    HttpContext.SignInAsync(
                       CookieAuthenticationDefaults.AuthenticationScheme,
                       new ClaimsPrincipal(claimsIdentity),
                       new AuthenticationProperties
                       {

                       });
                    return RedirectToAction("Index", "Home");

                }
                return View();
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }


    }

}
