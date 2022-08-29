using MealManagementSytem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MealManagementSytem.Entities
{
    public class PreviousAmount : PreviousAccount
    {
        [NotMapped]
        public string MemberName { get; set; }
    }
}
