using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozbelsan.DAL.Entities
{
    public class PersonUnit : Audit , IEntity , ISoftDelete
    {
        public int Id { get; set; }
        public string UnitName { get; set; }
        public string Department { get; set; }
        public int PersonelNumber { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Person> Persons { get; set; } // BİRİMDEN PERSONELE GECEBILIRIZ AMA BIR BIRIMDEN BIRDEN FAZLA PERSONELE GECECEĞİMİZ İÇİN LİSTESİNİ BURAYA EKLİYORUZ
    }
}
