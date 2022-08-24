using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MealManagementSytem.Models
{
    public class MealDetail
    {
        [Key]
        public int MealId { get; set; }
        [Required]
        [ForeignKey("MemberId")]
        public int MemberId { get; set; }
        public int Lunch { get; set; }
        public int Dinner { get; set; }
       [Required]
        public DateTime Date { get; set; }
        [Required]
        public int Status { get; set; }
        public int GuestLunch { get; set; }
        public int GuestDinner { get; set; }

    }
}
