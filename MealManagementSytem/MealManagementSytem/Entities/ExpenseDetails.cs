using MealManagementSytem.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealManagementSytem.Entities
{
    internal class ExpenseDetails: Expense
    {
        [NotMapped]
        public string MemberName { get; set; }

    }
}