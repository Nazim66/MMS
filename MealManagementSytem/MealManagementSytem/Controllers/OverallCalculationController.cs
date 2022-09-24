using MealManagementSytem.Data;
using MealManagementSytem.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace MealManagementSytem.Controllers
{
    [Authorize(Roles = "Admin, User, Super")]
    public class OverallCalculationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OverallCalculationController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            dynamic mymodel = new ExpandoObject();

            var date = System.DateTime.Now;
            var currentDate = date.Date;

            var totalExpenses = _context.Expenses.Where(x => x.Date.Month == currentDate.Month && x.Date.Year == currentDate.Year).Sum(e => e.Amount);

            var totalLunch = _context.Details.Where(x => x.Date.Month == currentDate.Month && x.Date.Year == currentDate.Year).Sum(e => e.Lunch);
            var totalGuestLunch = _context.Details.Where(x => x.Date.Month == currentDate.Month && x.Date.Year == currentDate.Year).Sum(e => e.GuestLunch);
            var totalDinner = _context.Details.Where(x => x.Date.Month == currentDate.Month && x.Date.Year == currentDate.Year).Sum(e => e.Dinner);
            var totalGuestDinner = _context.Details.Where(x => x.Date.Month == currentDate.Month && x.Date.Year == currentDate.Year).Sum(e => e.GuestDinner);
            var totalMeals = (totalLunch + totalGuestLunch + totalDinner + totalGuestDinner);

            var MealRate = totalExpenses / totalMeals;

            var overallDepositCalculationbyAll =
                                       from d in _context.Deposites
                                       join l in _context.Members on d.MemberId equals l.MemberId 
                                       join p in _context.PreviousAccounts on d.MemberId equals p.MemberId
                                       where d.Date.Month == date.Month && d.Date.Year == date.Year
                                       && p.Date.Month == date.Month && p.Date.Year == date.Year
                                       group d by new {d.MemberId , l.MemberName, p.Amount } into mm
                                       select new ToalCalculation
                                       {
                                           MemberId = mm.Key.MemberId,
                                           TotalDeposit = (int)mm.Sum(x=> x.Amount),
                                           Name = mm.Key.MemberName,
                                           PreviousAmount = mm.Key.Amount,

                                       };

            var overallMealCalculationbyAll =
                                        from mem in _context.Members
                                        join dl in _context.Details on mem.MemberId equals dl.MemberId
                                        where dl.Date.Month == date.Month && dl.Date.Year == date.Year
                                        group dl by new { dl.MemberId, mem.MemberName } into dd
                                        select new ToalCalculation
                                        {
                                            MemberId = dd.Key.MemberId,
                                            TotalCost = (double)System.Math.Round((dd.Sum(x => x.Lunch) + dd.Sum(x => x.GuestLunch) + dd.Sum(x => x.Dinner) + dd.Sum(x => x.GuestDinner)) * MealRate,2),
                                            TotalMeal = dd.Sum(x => x.Lunch) + dd.Sum(x => x.GuestLunch) + dd.Sum(x => x.Dinner) + dd.Sum(x => x.GuestDinner)
                                        };

            mymodel.DepoistCalculation = overallDepositCalculationbyAll;
            mymodel.MealCalculation = overallMealCalculationbyAll;
            return View(mymodel);
        }

        public IActionResult OverallExpenseCalculation()
        {
            var date = System.DateTime.Now;
            var currentDate = date.Date;
            var overallExpenses = _context.Expenses.Where(x => x.Date.Month == currentDate.Month && x.Date.Year == currentDate.Year).Sum(e => e.Amount);
            return Json(overallExpenses);
        }


        public IActionResult OverallMealAndExpense()
        {
            dynamic mymealratemodel = new ExpandoObject();

            var date = System.DateTime.Now;
            var currentDate = date.Date;

            mymealratemodel.overallExpenseCount = _context.Expenses.Where(x => x.Date.Month == currentDate.Month && x.Date.Year == currentDate.Year).Sum(e => e.Amount);

            var totalLunch = _context.Details.Where(x => x.Date.Month == currentDate.Month && x.Date.Year == currentDate.Year).Sum(e => e.Lunch);
            var totalGuestLunch = _context.Details.Where(x => x.Date.Month == currentDate.Month && x.Date.Year == currentDate.Year).Sum(e => e.GuestLunch);
            var totalDinner = _context.Details.Where(x => x.Date.Month == currentDate.Month && x.Date.Year == currentDate.Year).Sum(e => e.Dinner);
            var totalGuestDinner = _context.Details.Where(x => x.Date.Month == currentDate.Month && x.Date.Year == currentDate.Year).Sum(e => e.GuestDinner);
            mymealratemodel.overAllMealsCount = (totalLunch + totalGuestLunch + totalDinner + totalGuestDinner);

            return Json(mymealratemodel);
        }

    }
}
