using MealManagementSytem.Data;
using MealManagementSytem.Entities;
using MealManagementSytem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MealManagementSytem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;


        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var date = System.DateTime.Now;
            var name = from s in _context.Schedules
                       join m in _context.Members on s.MemberId equals m.MemberId
                       where s.Date.Month == date.Month && s.Date.Year == date.Year && s.Date.Day == date.Day
                       select new ViewName
                       {
                          MemberName = m.MemberName
                       };

            var value = name.ToList();
            ViewBag.bazarPersonName = value;
            return View();
        }
        public IActionResult TodaysMeal()
        {
            var date = System.DateTime.Now;

            var allMeals =
                           from c in _context.Details
                           join m in _context.Members on c.MemberId equals m.MemberId
                           where c.Date.Day == date.Day &&  c.Date.Year == date.Year && c.Date.Month == date.Month
                           select new AllMeal
                           {
                               GuestDinner = c.GuestDinner,
                               GuestLunch = c.GuestLunch,
                               MemberName = m.MemberName,
                               MemberId = m.MemberId,
                               Lunch = c.Lunch,
                               Dinner = c.Dinner,
                               Date = c.Date

                           };

            var value = allMeals.ToList().OrderByDescending(x => x.Date);

            return Json(value);
        }


        public IActionResult MealCalculationForTodays()
        {
            var date = System.DateTime.Now;
            var currentDate = date.Date;
            var totalLunch = _context.Details.Where(x => x.Date.Month == currentDate.Month && x.Date.Year == currentDate.Year && x.Date.Day == currentDate.Day).Sum(e => e.Lunch);
            var totalGuestLunch = _context.Details.Where(x => x.Date.Month == currentDate.Month && x.Date.Year == currentDate.Year && x.Date.Day == currentDate.Day).Sum(e => e.GuestLunch);
            var totalDinner = _context.Details.Where(x => x.Date.Month == currentDate.Month && x.Date.Year == currentDate.Year && x.Date.Day == currentDate.Day).Sum(e => e.Dinner);
            var totalGuestDinner = _context.Details.Where(x => x.Date.Month == currentDate.Month && x.Date.Year == currentDate.Year && x.Date.Day == currentDate.Day).Sum(e => e.GuestDinner);
            var totalMeals = (totalLunch + totalGuestLunch + totalDinner + totalGuestDinner);
            return Json(totalMeals);
        }
    }
}
