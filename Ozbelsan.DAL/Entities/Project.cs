using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozbelsan.DAL.Entities
{
   public class Project : Audit , IEntity , ISoftDelete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DeliveryDate { get; set; } // teslim tarihi
        public bool IsDeleted { get; set; }

        public ICollection<ProjectPerson> ProjectPersons { get; set; } // JUCNTİON CLASSSINI BURAYA LİSTELEDİK (İÇERDİĞİ SEYDEN BIRI PROJECT OLDUGU ICIN)
    }
}
