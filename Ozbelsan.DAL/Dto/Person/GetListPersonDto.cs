using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozbelsan.DAL.Dto.Person
{
    public class GetListPersonDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PersonNumber { get; set; }
        public int PersonUnitId { get; set; }
        public string UnitName { get; set; }
    }
}
