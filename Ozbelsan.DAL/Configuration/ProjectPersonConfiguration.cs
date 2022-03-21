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
    public class ProjectPersonConfiguration : IEntityTypeConfiguration<ProjectPerson>
    {
        public void Configure(EntityTypeBuilder<ProjectPerson> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.HasOne(p => p.ProjectFK).WithMany(p => p.ProjectPersons).HasForeignKey(p => p.ProjectId);
            builder.HasOne(p => p.PersonFK).WithMany(p => p.ProjectPersons).HasForeignKey(p => p.PersonId);
        }
    }
}
