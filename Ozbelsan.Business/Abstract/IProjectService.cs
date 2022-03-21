using Ozbelsan.DAL.Dto.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozbelsan.Business.Abstract
{
    public interface IProjectService
    {
        Task<List<GetListProjectDto>> GetAllProjects();
        Task<GetProjectDto> GetProjectById(int ProjectId);

        Task<int> AddProject(AddProjectDto addProjectDto);
        Task<int> UpdateProject(UpdateProjectDto updateProjectDto);

        Task<int> DeleteProject(int ProjectId);

    }
}
