using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozbelsan.DAL.Entities
{
    public class ProjectPerson : Audit, IEntity, ISoftDelete
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }
        public Project ProjectFK { get; set; }
        public int PersonId { get; set; }
        public Person PersonFK { get; set; }
        public bool IsDeleted { get ; set; }
    }
}
