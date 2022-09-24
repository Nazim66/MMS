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
    //[Authorize(Roles = "Admin, Super")]
    //OR
    [Authorize]
    public class ScheduleController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ScheduleController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var date = System.DateTime.Now;
            var data = from s in _context.Schedules
                       join m in _context.Members on s.MemberId equals m.MemberId
                       where s.Date.Month == date.Month && s.Date.Year == date.Year 
                       select new ViewName
                       {
                           MemberName = m.MemberName,
                           Date = s.Date,
                       };
            var list = data.ToList();
            return View(list);
        }
        public IActionResult AddSchedule(List<Schedule> prm)
        {
            List<string> checkDate  = FindAlreadyEntryDate();
            var Status = "";
            var flag = 0;
            foreach(var value in checkDate) { 
                foreach(var item in prm)
                {
                    if(item.Date.ToShortDateString() == value)
                    {
                        flag = 1;
                        Status = "Already Exist For Day of " + item.Date.ToShortDateString();
                        return Json(Status);
                    }
                }
            }
            if (flag != 1)
            {
                _context.Schedules.AddRange(prm);
                _context.SaveChanges();
                Status = "Successfully save to the Schedule!!!";
                return Json(Status);
            }
            else
            {
                Status = "Error Occured!!!";
                return Json(Status);
            }
                    
        }
        public List<string> FindAlreadyEntryDate()
        {
            var dt = System.DateTime.Now;
            var list = new  List<string >();
            var getData = _context.Schedules.Select(e => e.Date.Date).Where(x => x.Date.Month == dt.Month && x.Date.Year == dt.Year);
            foreach (var val in getData)
            {
                var dt_value = val.Date.ToShortDateString();
                list.Add(dt_value);
            }
            ViewBag.getScheduleData = list;
            return list;
        }
    } 
}
