using MealManagementSytem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MealManagementSytem.Entities
{
    public class DepositDetails: Deposite
    {
        [NotMapped]
        public string MemberName { set; get; }
    }
}
