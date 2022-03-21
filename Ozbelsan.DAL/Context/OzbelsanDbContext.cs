using Microsoft.EntityFrameworkCore;
using Ozbelsan.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ozbelsan.DAL.Context
{
    public class OzbelsanDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder) //TOPLU DEĞİL KISIM KISIM YAZDIM SEN BU KONFIGURASYONLARI 
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //TEK TEK OKU INCELE BUL

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // Veritabanı sağlayıcı
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-M227QJH7\\SQLEXPRESS;Database=OzbelsanDB;Trusted_Connection=True;");
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<PersonUnit> PersonUnits { get; set; }
        public DbSet<ProjectPerson> ProjectPersons { get; set; }
    }
}
