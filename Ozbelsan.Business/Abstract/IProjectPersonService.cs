using Ozbelsan.DAL.Dto.ProjectPerson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozbelsan.Business.Abstract
{
    public interface IProjectPersonService
    {
        Task<List<GetListProjectPersonDto>> GetAllProjectPersons();
        Task<GetProjectPersonDto> GetProjectPersonById(int projectPersonId);
        Task<int> AddProjectPerson(AddProjectPersonDto addProjectPersonDto);
        Task<int> UpdateProjectPerson(UpdateProjectPersonDto updateProjectPersonDto);
        Task<int> DeleteProjectPerson(int projectPersonId);
    }
}
