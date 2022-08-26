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
    public class DepositeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DepositeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndividualDeposites()
        {
            var id = HttpContext.Session.GetString("UserId");
            var DepositeList = _context.Deposites.Where(e=> e.MemberId == Convert.ToInt32(id)).ToList();
            return Json(DepositeList);
        }

        public IActionResult IndividualDepositCalculation()
        {
            var id = HttpContext.Session.GetString("UserId");
            var date = System.DateTime.Now;
            var currentDate = date.Date;
            var totalIndividualDeposits = _context.Deposites.Where(x => x.Date.Month == currentDate.Month && x.Date.Year == currentDate.Year && x.MemberId == Convert.ToInt32(id)).Sum(e => e.Amount).ToString();
            return Json(totalIndividualDeposits);
        }

        public IActionResult AllDeposits()
        {
            return View();
        }
        public IActionResult DepositedByAll()
        {
            var depositedbyAll =
                            from d in _context.Deposites
                            join m in _context.Members on d.MemberId equals m.MemberId
                            select new DepositDetails
                            {
                                DepositeId = d.DepositeId,
                                MemberName = m.MemberName,
                                MemberId = m.MemberId,
                                Amount = d.Amount,
                                Date = d.Date

                            };

            var value = depositedbyAll.ToList();
            return Json(value);
        }

        public IActionResult DepositCalculation()
        {
            var date = System.DateTime.Now;
            var currentDate = date.Date;
            var totalDeposits = _context.Deposites.Where(x => x.Date.Month == currentDate.Month && x.Date.Year == currentDate.Year).Sum(e => e.Amount);
            return Json(totalDeposits);
        }

        public IActionResult GetMemberName()
        {
            var memberList = _context.Members.ToList();
            return Json(memberList);
        }

        public IActionResult AddDepositedAmount(Deposite prm)
        {
            _context.Add(prm);
            _context.SaveChanges();
            return new JsonResult(new { Status = "Successfully Added" });
        }
    }
}
