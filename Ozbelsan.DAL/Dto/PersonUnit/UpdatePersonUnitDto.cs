using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozbelsan.DAL.Dto.PersonUnit
{
   public class UpdatePersonUnitDto : IDto
    {
        public int Id { get; set; }
        public string UnitName { get; set; }
        public string Department { get; set; }
        public int PersonelNumber { get; set; }
    }
}
