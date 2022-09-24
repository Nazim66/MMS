using MealManagementSytem.Data;
using MealManagementSytem.Entities;
using MealManagementSytem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealManagementSytem.Controllers
{
    [Authorize(Roles = "Admin, Super")]
    public class PreviousAccountController : Controller
    {

        private readonly ApplicationDbContext _context;

        public PreviousAccountController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PreviousAmountByAll()
        {
            var PreviousamountbyAll =
                            from d in _context.PreviousAccounts
                            join m in _context.Members on d.MemberId equals m.MemberId
                            select new PreviousAmount
                            {
                                PreviousAccountId = d.PreviousAccountId,
                                MemberName = m.MemberName,
                                MemberId = m.MemberId,
                                Amount = d.Amount,
                                Date = d.Date

                            };

            var value = PreviousamountbyAll.ToList();
            return Json(value);
        }

        public IActionResult GetPreviousAmountMemberName()
        {
            var memberList = _context.Members.ToList();
            return Json(memberList);
        }

        public IActionResult AddPreviousAmount(PreviousAccount prm)
        {
            var date = System.DateTime.Now;
            prm.Date = date.Date;
            var Status = "";
            var id = prm.MemberId;
            var checkValidation = _context.PreviousAccounts.FirstOrDefault(e => e.MemberId == id && e.Date.Month == date.Month);
            if (checkValidation == null)
            {

                if (prm.PreviousAccountId == 0)
                {
                    _context.Add(prm);
                    Status = "Successfully Saved to the Database";
                }
                else
                {
                    _context.PreviousAccounts.Update(prm);
                    Status = "Successfully Update to the Database";
                }
                _context.SaveChanges();
                return new JsonResult(Status);

            }
            else
            {
                return new JsonResult(Status = "Already Data Exists for Current Month!!");
            }
        }

        public IActionResult UpdatePreviousAccountById(int id)
        {
            var previousAccountInfo = _context.PreviousAccounts.FirstOrDefault(e => e.PreviousAccountId == id);
            return Json(previousAccountInfo);
        }

        public IActionResult PreviousAccountRemove(int id)
        {
            var status = "";
            var remove = _context.PreviousAccounts.FirstOrDefault(x => x.PreviousAccountId == id);
            _context.PreviousAccounts.Remove(remove);
            _context.SaveChanges();
            status = "Successfully Deleted";
            return Json(status);
        }

        public IActionResult PreviousAmountCalculation()
        {
            var date = System.DateTime.Now;
            var currentDate = date.Date;
            var totalPreviousAmount = _context.PreviousAccounts.Where(x => x.Date.Month == currentDate.Month && x.Date.Year == currentDate.Year).Sum(e => e.Amount);
            return Json(totalPreviousAmount);
        }
    }
}
