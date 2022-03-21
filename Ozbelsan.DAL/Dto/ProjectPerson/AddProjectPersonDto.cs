using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozbelsan.DAL.Dto.ProjectPerson
{
    public class AddProjectPersonDto : IDto
    {
        public int ProjectId { get; set; }
        public int PersonId { get; set; }
    }
}
