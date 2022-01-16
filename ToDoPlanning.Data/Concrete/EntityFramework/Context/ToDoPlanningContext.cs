using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPlanning.Data.Concrete.EntityFramework.Mapping;
using ToDoPlanning.Entity.Concrete;

namespace ToDoPlanning.Data.Concrete.EntityFramework.Context
{
    public class ToDoPlanningContext : DbContext
    {
        public DbSet<ToDoProvider> ToDoProviders { get; set; }
        public DbSet<ToDoTask> ToDoTasks { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<TaskPlan> TaskPlans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb);Database=ToDoPlanner;Trusted_Connection=True;Connect Timeout=30;MultipleActiveResultSets=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ToDoProviderMap());
            modelBuilder.ApplyConfiguration(new ToDoTaskMap());
            modelBuilder.ApplyConfiguration(new DeveloperMap());
            modelBuilder.ApplyConfiguration(new TaskPlanMap());
        }
    }
}
