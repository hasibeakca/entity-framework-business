using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozbelsan.DAL.Entities
{
    public class Person : Audit, IEntity , ISoftDelete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PersonNumber { get; set; }
        public bool IsDeleted { get; set; } // BURAYA KADAR KENDI OZELLIKLERI
        public ICollection<ProjectPerson> ProjectPersons { get; set; } //JUNCTİON U BURAYA LİSTELEDİK
        public int PersonUnitId { get; set; }  // PERSONELDEN BİRİMİNE ULAŞABILIRIZ BIRIMIN ID SINI ALDIK
        public PersonUnit PersonUnitFK { get; set; }
    }
}
