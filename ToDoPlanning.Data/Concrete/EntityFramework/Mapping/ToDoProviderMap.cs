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
    public class ToDoProviderMap : IEntityTypeConfiguration<ToDoProvider>
    {
        public void Configure(EntityTypeBuilder<ToDoProvider> builder)
        {
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID).ValueGeneratedOnAdd();

            builder.Property(a => a.Name).HasMaxLength(100);
            builder.Property(a => a.Name).IsRequired(true);

            builder.Property(a => a.Description).IsRequired();
            builder.Property(a => a.Description).HasMaxLength(300);

            builder.Property(a => a.Url).IsRequired();
            builder.Property(a => a.Url).HasMaxLength(300);

            builder.Property(a => a.IsActive).IsRequired();

            builder.Property(a => a.CreatedDate).IsRequired();



            builder.ToTable("Tbl_ToDoProvider");

            builder.HasData(
                new ToDoProvider
                {
                    ID = 1,
                    Name = "First Provider",
                    Description = "Mock 1 provider. Json veri gelir",
                    Url = "http://www.mocky.io/v2/5d47f24c330000623fa3ebfa",                    
                    IsActive = true,                    
                    CreatedDate = DateTime.Now
                },
                new ToDoProvider
                {
                    ID = 2,
                    Name = "Second Provider",
                    Description = "Mock 2 provider. Json veri gelir",
                    Url = "http://www.mocky.io/v2/5d47f235330000623fa3ebf7",
                    IsActive = true,
                    CreatedDate = DateTime.Now
                }
            );
        }
    }
}
