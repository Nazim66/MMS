using MealManagementSytem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealManagementSytem.Entities;

namespace MealManagementSytem.Data
{
    public class ApplicationDbContext: DbContext
    {
  
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Member> Members { set; get; }
        public DbSet<MealDetail> Details { set; get; }
        public DbSet<Deposite> Deposites { set; get; }
        public DbSet<Expense> Expenses { set; get; }
        public DbSet<Other> Others { set; get; }
        public DbSet<PreviousAccount> PreviousAccounts { set; get; }
        public DbSet<Schedule> Schedules { set; get; }
    }
}
