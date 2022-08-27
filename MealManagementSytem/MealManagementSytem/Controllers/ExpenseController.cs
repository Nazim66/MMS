using MealManagementSytem.Data;
using MealManagementSytem.Entities;
using MealManagementSytem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealManagementSytem.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExpenseController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ExpensesByAll()
        {
            var expensesbyAll =
                            from d in _context.Expenses
                            join m in _context.Members on d.MemberId equals m.MemberId
                            select new ExpenseDetails
                            {
                                ExpenseId = d.ExpenseId,
                                MemberName = m.MemberName,
                                MemberId = m.MemberId,
                                Amount = d.Amount,
                                BazarDetail = d.BazarDetail,
                                Date = d.Date

                            };

            var value = expensesbyAll.ToList();
            return Json(value);
        }

        public IActionResult ExpenseCalculation()
        {
            var date = System.DateTime.Now;
            var currentDate = date.Date;
            var totalExpenses = _context.Expenses.Where(x => x.Date.Month == currentDate.Month && x.Date.Year == currentDate.Year).Sum(e => e.Amount);
            return Json(totalExpenses);
        }

        public IActionResult GetExpensesMemberName()
        {
            var memberList = _context.Members.ToList();
            return Json(memberList);
        }

        public IActionResult AddExpensesAmount(Expense prm)
        {
            _context.Add(prm);
            _context.SaveChanges();
            return new JsonResult(new { Status = "Successfully Added" });
        }
    }
}
