using MealManagementSytem.Data;
using MealManagementSytem.Entities;
using MealManagementSytem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealManagementSytem.Controllers
{
    public class MealController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MealController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndividualMealDetails()
        {
            var id = HttpContext.Session.GetString("UserId");
            var MealList = _context.Details.Where(e => e.MemberId == Convert.ToInt32(id) && e.MemberId !=0).ToList();
         
            return Json(MealList);
        }

        public IActionResult IndividualMealCalculation()
        {
            var id = HttpContext.Session.GetString("UserId");
            var date = System.DateTime.Now;
            var currentDate = date.Date;
            var totalIndividualLunch = _context.Details.Where(x => x.Date.Month == currentDate.Month && x.Date.Year == currentDate.Year && x.MemberId == Convert.ToInt32(id)).Sum(e => e.Lunch);
            var totalIndividualGuestLunch = _context.Details.Where(x => x.Date.Month == currentDate.Month && x.Date.Year == currentDate.Year && x.MemberId == Convert.ToInt32(id)).Sum(e => e.GuestLunch);
            var totalIndividualDinner = _context.Details.Where(x => x.Date.Month == currentDate.Month && x.Date.Year == currentDate.Year && x.MemberId == Convert.ToInt32(id)).Sum(e => e.Dinner);
            var totalIndividualGuestDinner = _context.Details.Where(x => x.Date.Month == currentDate.Month && x.Date.Year == currentDate.Year && x.MemberId == Convert.ToInt32(id)).Sum(e => e.GuestDinner);
            var totalIndividualMeals = (totalIndividualLunch + totalIndividualGuestLunch + totalIndividualDinner + totalIndividualGuestDinner);
            return Json(totalIndividualMeals);
        }
        public IActionResult AllMeals()
        {
            return View();
        }
        public IActionResult AllMemberMeals()
        {
            var id = HttpContext.Session.GetString("UserId");
            var allMeals =
                           from c in _context.Details
                           join m in _context.Members on c.MemberId equals m.MemberId
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

            var value = allMeals.ToList().OrderByDescending(x=> x.Date);

            return Json(value);
        }


        public IActionResult MealCalculation()
        {
            var date = System.DateTime.Now;
            var currentDate = date.Date;
            var totalLunch = _context.Details.Where(x => x.Date.Month == currentDate.Month && x.Date.Year == currentDate.Year).Sum(e => e.Lunch);
            var totalGuestLunch = _context.Details.Where(x => x.Date.Month == currentDate.Month && x.Date.Year == currentDate.Year).Sum(e => e.GuestLunch);
            var totalDinner = _context.Details.Where(x => x.Date.Month == currentDate.Month && x.Date.Year == currentDate.Year).Sum(e => e.Dinner);
            var totalGuestDinner = _context.Details.Where(x => x.Date.Month == currentDate.Month && x.Date.Year == currentDate.Year).Sum(e => e.GuestDinner);
            var totalMeals = (totalLunch + totalGuestLunch + totalDinner + totalGuestDinner);
            return Json(totalMeals);
        }

        public IActionResult AddMealDetails (MealDetail prm)
        {
            var id = HttpContext.Session.GetString("UserId");
            prm.MemberId = Convert.ToInt32(id);
            _context.Add(prm);
            _context.SaveChanges();
            return new JsonResult(new { Status = "Successfully Added" });
        }

    }
}
