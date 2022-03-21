using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ozbelsan.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozbelsan.DAL.Configuration
{
    public class PersonUnitConfiguration : IEntityTypeConfiguration<PersonUnit>
    {
        public void Configure(EntityTypeBuilder<PersonUnit> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.UnitName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.PersonelNumber).IsRequired();
            builder.Property(p => p.Department).IsRequired().HasMaxLength(50);
           
            


        }
    }
}
