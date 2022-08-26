using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MealManagementSytem.Models
{
    public class Deposite
    {
        [Key]
        public int DepositeId { get; set; }
        [ForeignKey("MemberId")]
        public int MemberId { get; set; }
        [Required]
        public double Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
