using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozbelsan.DAL.Dto.ProjectPerson
{
    public class UpdateProjectPersonDto : IDto
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int ProjectId { get; set; }
    }
}
