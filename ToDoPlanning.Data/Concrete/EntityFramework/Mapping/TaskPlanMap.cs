using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPlanning.Entity.Concrete;

namespace ToDoPlanning.Data.Concrete.EntityFramework.Mapping
{
    public class TaskPlanMap : IEntityTypeConfiguration<TaskPlan>
    {
        public void Configure(EntityTypeBuilder<TaskPlan> builder)
        {
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID).ValueGeneratedOnAdd();

            builder.Property(a => a.Name).HasMaxLength(100);
            builder.Property(a => a.Name).IsRequired(true);

            builder.Property(a => a.Description).IsRequired();
            builder.Property(a => a.Description).HasMaxLength(300);

            builder.Property(a => a.TotalHour).IsRequired();

            builder.Property(a => a.TotalWeek).IsRequired();

            builder.Property(a => a.IsActive).IsRequired();

            builder.Property(a => a.CreatedDate).IsRequired();

            builder.Property(a => a.StartDate).IsRequired();

            builder.Property(a => a.EndDate).IsRequired();

            builder.HasMany<ToDoTask>(a => a.ToDoTasks).WithOne(c => c.TaskPlan).HasForeignKey(a => a.TaskPlanID);


            builder.ToTable("Tbl_TaskPlan");
        }
    }
}
