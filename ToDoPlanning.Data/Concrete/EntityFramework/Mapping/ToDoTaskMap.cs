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
    public class ToDoTaskMap :IEntityTypeConfiguration<ToDoTask>
    {
        public void Configure(EntityTypeBuilder<ToDoTask> builder)
        {
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID).ValueGeneratedOnAdd();

            builder.Property(a => a.Difficulty).IsRequired(true);

            builder.Property(a => a.Duration).IsRequired();

            builder.Property(a => a.ExternalID).IsRequired();
            builder.Property(a => a.ExternalID).HasMaxLength(500);

            builder.Property(a => a.IsActive).IsRequired();

            builder.Property(a => a.CreatedDate).IsRequired();

            builder.Property(a => a.isPlanned).IsRequired();

            builder.HasOne<ToDoProvider>(a => a.ToDoProvider).WithMany(c => c.ToDoTasks).HasForeignKey(a => a.ToDoProviderID);


            builder.ToTable("Tbl_ToDoTask");

        }
    }
}
