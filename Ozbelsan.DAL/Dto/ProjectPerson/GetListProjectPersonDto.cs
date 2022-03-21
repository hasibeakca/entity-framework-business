using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozbelsan.DAL.Dto.ProjectPerson
{
    public class GetListProjectPersonDto : IDto
    {
        public int PersonId { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int DeliveryDate { get; set; }
        public string PersonName { get; set; }
        public string PersonSurname { get; set; }
        public int PersonNumber { get; set; }
    }
}
