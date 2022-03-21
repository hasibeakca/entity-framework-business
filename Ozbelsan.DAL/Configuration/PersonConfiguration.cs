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
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(p => p.Id); //HASKEY PRİMARY KEY MANASINA GELDİĞİNDEN SADECE ID DE YAZILIR 
            builder.Property(p => p.Id).ValueGeneratedOnAdd(); //ID SIRASINI ATLAMADAN DEVAM ETSİN DIYE
            builder.Property(p => p.Name).HasMaxLength(20).IsRequired(); //ISREQUİRED BOŞ BRAKILAMAZ DEMEK AMAAAA  BU DEĞİŞKENİ TANIMLARKEN VERİ TÜRÜNÜN YANINA ? YAZARSAK BU BOŞ BIRAKILABILIR OLUR 
            builder.Property(p => p.Surname).HasMaxLength(20).IsRequired();
            builder.Property(p => p.PersonNumber).IsRequired();// haskey primary key manasında sadece ıd de
            builder.Property(p => p.PersonUnitId).IsRequired(); // PERSONELİN BİRİMİNİ BELİRTMEMİZ GEREKTİĞİMİZ
            builder.HasOne(p => p.PersonUnitFK).WithMany(p => p.Persons).HasForeignKey(p => p.PersonUnitId);

            
        }
    }
}
