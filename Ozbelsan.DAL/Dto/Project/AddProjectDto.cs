using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozbelsan.DAL.Dto.Project
{
    public class AddProjectDto : IDto
    {
        public string Name { get; set; }
        public int DeliveryDate { get; set; }
       
    }
}
