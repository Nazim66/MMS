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
                _context.Add(prm);
                _context.SaveChanges();
                Status = "Data is Saved Successfully";
            }
            else
            {
                Status = "Data already exists!";
            }

            return Json(Status);
               
        }
    }
}
