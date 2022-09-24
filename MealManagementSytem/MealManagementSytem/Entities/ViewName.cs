using MealManagementSytem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealManagementSytem.Entities
{
    public class ViewName: Schedule
    {
        public string MemberName { set; get; }
    }
}
