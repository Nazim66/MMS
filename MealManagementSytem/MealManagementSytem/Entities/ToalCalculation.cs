using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealManagementSytem.Entities
{
    public class ToalCalculation
    {
        public int TotalDeposit { get; set; }
        public int MatchId { get; set; }
        public int MemberId { get; set; }
        public string Name { get; set; }
        public int TotalMeal { get; set; }
        public int TotalMealCount { get; set; }
        public double PreviousAmount { get; set; }
        public double TotalCost { get; set; }
        public double CurrentBalance  { get; set; }
    }
}
