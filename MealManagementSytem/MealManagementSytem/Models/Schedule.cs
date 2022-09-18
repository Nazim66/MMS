using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MealManagementSytem.Models
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }
        [ForeignKey("MemberId")]
        public int MemberId { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
