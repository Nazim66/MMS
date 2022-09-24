using MealManagementSytem.Data;
using MealManagementSytem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealManagementSytem.Controllers
{
    [Authorize(Roles = "Admin, Super")]
    public class MemberController : Controller
    {

        private readonly ApplicationDbContext _context;

        public MemberController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllMember()
        {
            var MemberList = _context.Members.Where(x=> x.MemberType != "Super").ToList();
            return Json(MemberList);
        }

        public IActionResult AddMember(Member prm)
        {
            var Status = "";
            if (prm.MemberId.ToString() == null)
            {
                prm.MemberId = 0;
            }
            if(prm.MemberId == 0)
            {
                _context.Add(prm);
                Status = "Successfully Saved to the Database";
            }
            else
            {
                _context.Members.Update(prm);
                Status = "Successfully Update to the Database";
            }
            _context.SaveChanges();
            return new JsonResult(Status);
        }

        public IActionResult UpdateMemberById(int id)
        {
            var memberInfo = _context.Members.FirstOrDefault(e => e.MemberId == id);
            return Json(memberInfo);
        }
        public IActionResult MemberRemove(int id)
        {
            var status = "";
            var remove = _context.Members.FirstOrDefault(x=> x.MemberId == id);
            _context.Members.Remove(remove);
            _context.SaveChanges();
            status = "Successfully Deleted";
            return Json(status);
        }
    }
}
