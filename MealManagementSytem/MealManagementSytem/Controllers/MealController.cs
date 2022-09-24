using MealManagementSytem.Data;
using MealManagementSytem.Entities;
using MealManagementSytem.Models;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin, User, Super")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndividualMealDetails()
        {
            var id = HttpContext.Session.GetString("UserId");
            var MealList = _context.Details.Where(e => e.MemberId == Convert.ToInt32(id) && e.MemberId != 0).ToList();

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
        [Authorize(Roles = "Admin")]
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
                               MealId = c.MealId,
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

        public IActionResult AddMealDetails(MealDetail prm)
        {
            var Status = "";
            if(prm.MealId == 0)
            {
                var dateForToday = System.DateTime.Now;
                var id = HttpContext.Session.GetString("UserId");
                var checkValidation = _context.Details.FirstOrDefault(x => x.MemberId == Convert.ToInt32(id) && x.Date.Date == dateForToday.Date);
                if (prm.GuestLunch >= 0 && prm.GuestDinner >= 0)
                {
                    var guestLunchLength = prm.GuestLunch;
                    var guestDinnerLength = prm.GuestDinner;
                    var length1 = guestLunchLength.ToString().Length;
                    var length2 = guestDinnerLength.ToString().Length;

                    if (checkValidation == null)
                    {
                        if (length1 <= 1 || length2 <= 1)
                        {
                            prm.MemberId = Convert.ToInt32(id);
                            _context.Add(prm);
                            _context.SaveChanges();
                            Status = "Data Successfully Saved!";
                        }
                        else
                        {
                            Status = "You Should Give 1 Digit!!!";
                        }

                    }
                    else
                    {
                        Status = "Already Inserted Todays Meal";

                    }
                }
                else
                {
                    Status = "You are Given Negetive Number of Meal For Guest!";
                }
            }
            else
            {
                if (prm.GuestLunch >= 0 && prm.GuestDinner >= 0 && prm.Lunch >= 0 && prm.Dinner >= 0)
                {
                    var guestLunchLength = prm.GuestLunch;
                    var lunchLength = prm.Lunch;
                    var dinnerLength = prm.Dinner;
                    var guestDinnerLength = prm.GuestDinner;
                    var gstLunch = guestLunchLength.ToString().Length;
                    var lunch = lunchLength.ToString().Length;
                    var gstDinner = guestDinnerLength.ToString().Length;
                    var dnr = dinnerLength.ToString().Length;

                    if (lunch <= 1 && gstLunch <= 1 && dnr <= 1 && gstDinner <= 1)
                    {
                        _context.Details.Update(prm);
                        _context.SaveChanges();
                        Status = "Data Updated Successfully!";
                    }
                    else
                    {
                        Status = "You Should Give 1 Digit!!!";
                    }
                }
                else
                {
                    Status = "You are Given Negetive Number of Meal For Guest!";
                }
            }

            return new JsonResult(Status);
        }


        public IActionResult CheckMealForIndividualUsers(int id)
        {

            return null;
        }

        public IActionResult UpdateMealById(int id)
        {
            var mealDetails = _context.Details.FirstOrDefault(x => x.MealId == id);
            return Json(mealDetails);
        }

        public IActionResult MealRemove(int id)
        {
            var status = "";
            var remove = _context.Details.FirstOrDefault(x => x.MealId == id);
            _context.Details.Remove(remove);
            _context.SaveChanges();
            status = "Successfully Deleted";
            return Json(status);
        }

    }
}
