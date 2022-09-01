using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MealManagementSytem.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
        [Required]
        public string MemberName { get; set; }
        [Required]
        public string MemberType { get; set; }
        [Required]
        public string MemberPass { get; set; }
    }
}
