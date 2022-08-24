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
                
            var DepositeList = _context.Deposites.ToList();
            return Json(DepositeList);
        }
        public IActionResult AllDeposits()
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
            return Json(depositedbyAll);
        }
    }
}
