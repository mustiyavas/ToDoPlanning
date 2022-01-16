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
    public class DeveloperMap : IEntityTypeConfiguration<Developer>
    {
        public void Configure(EntityTypeBuilder<Developer> builder)
        {
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID).ValueGeneratedOnAdd();

            builder.Property(a => a.Level).IsRequired(true);

            builder.Property(a => a.Hour).IsRequired();

            builder.Property(a => a.IsActive).IsRequired();

            builder.Property(a => a.CreatedDate).IsRequired();

            builder.ToTable("Tbl_Developer");

            builder.HasData(
                new Developer
                {
                    ID = 1,
                    Name = "DEV1",
                    Level =1 ,
                    Hour = 1,
                    IsActive = true,
                    CreatedDate = DateTime.Now
                },
                new Developer
                {
                    ID = 2,
                    Name = "DEV2",
                    Level = 2,
                    Hour = 1,
                    IsActive = true,
                    CreatedDate = DateTime.Now
                },
                new Developer
                {
                    ID = 3,
                    Name = "DEV3",
                    Level = 3,
                    Hour = 1,
                    IsActive = true,
                    CreatedDate = DateTime.Now
                },
                new Developer
                {
                    ID = 4,
                    Name = "DEV4",
                    Level = 4,
                    Hour = 1,
                    IsActive = true,
                    CreatedDate = DateTime.Now
                },
                new Developer
                {
                    ID = 5,
                    Name = "DEV5",
                    Level = 5,
                    Hour = 1,
                    IsActive = true,
                    CreatedDate = DateTime.Now
                }
            );

        }
    }
}
