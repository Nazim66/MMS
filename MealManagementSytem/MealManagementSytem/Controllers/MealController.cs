using MealManagementSytem.Data;
using MealManagementSytem.Models;
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
            var MealList = _context.Details.ToList();
            return Json(MealList);
        }

        public IActionResult AddMealDetails (MealDetail prm)
        {
            _context.Add(prm);
            _context.SaveChanges();
            return new JsonResult(new { Status = "Successfully Added" });
        }

    }
}
