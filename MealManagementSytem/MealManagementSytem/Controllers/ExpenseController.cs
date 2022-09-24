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
    [Authorize(Roles = "Admin, User, Super")]
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
            var date = System.DateTime.Now;
            var expensesbyAll =
                            from d in _context.Expenses
                            join m in _context.Members on d.MemberId equals m.MemberId
                            where d.Date.Month == date.Month
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
            var Status = "";

            if (prm.ExpenseId == 0)
            {
                _context.Add(prm);
                Status = "Successfully Saved to the Database";
            }
            else
            {
                _context.Expenses.Update(prm);
                Status = "Successfully Update to the Database";
            }
            _context.SaveChanges();
            return new JsonResult(Status);
        }

        public IActionResult UpdateExpenseById(int id)
        {
            var expenseInfo = _context.Expenses.FirstOrDefault(e => e.ExpenseId == id);
            return Json(expenseInfo);
        }

        public IActionResult ExpenseRemove(int id)
        {
            var status = "";
            var remove = _context.Expenses.FirstOrDefault(x => x.ExpenseId == id);
            _context.Expenses.Remove(remove);
            _context.SaveChanges();
            status = "Successfully Deleted";
            return Json(status);
        }
        public IActionResult CheckUserType()
        {
            var type = HttpContext.Session.GetString("UserType");
            return Json(type);
        }
    }
}
