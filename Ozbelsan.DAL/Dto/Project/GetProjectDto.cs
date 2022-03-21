using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozbelsan.DAL.Dto.Project
{
    public class GetProjectDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DeliveryDate { get; set; }
        public string PersonName { get; set; }
    }
}
