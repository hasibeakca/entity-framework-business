using Microsoft.EntityFrameworkCore;
using Ozbelsan.Business.Abstract;
using Ozbelsan.DAL.Context;
using Ozbelsan.DAL.Dto.Project;
using Ozbelsan.DAL.Dto.ProjectPerson;
using Ozbelsan.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozbelsan.Business.Concrete
{
    public class ProjectService : IProjectService
    {
        private readonly OzbelsanDbContext _ozbelsanDbContext;

        public ProjectService(OzbelsanDbContext ozbelsanDbContext)
        {
            _ozbelsanDbContext = ozbelsanDbContext;
        }


        public async Task<int> AddProject(AddProjectDto addProjectDto)
        {
            var AddingProject = new Project
            {
                Name = addProjectDto.Name,
                DeliveryDate = addProjectDto.DeliveryDate,
               
            };
           await _ozbelsanDbContext.Projects.AddAsync(AddingProject);
            return await _ozbelsanDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteProject(int ProjectId)
        {
            var CurrentProject = await _ozbelsanDbContext.Projects.Where(p => !p.IsDeleted && p.Id == ProjectId).FirstOrDefaultAsync();
            if (CurrentProject == null)
            {
                return -1;
            }
            CurrentProject.IsDeleted = true;
            _ozbelsanDbContext.Projects.Update(CurrentProject);
            return await _ozbelsanDbContext.SaveChangesAsync();
        }

        public async Task<List<GetListProjectDto>> GetAllProjects()
        {
            return await _ozbelsanDbContext.Projects.Where(p => !p.IsDeleted).Select(p => new GetListProjectDto
            {
                Id = p.Id,
                Name = p.Name,
                DeliveryDate = p.DeliveryDate,
            }).ToListAsync();
        }

        public async Task<GetProjectDto> GetProjectById(int ProjectId)
        {
            return await _ozbelsanDbContext.Projects.Where(p => !p.IsDeleted && p.Id == ProjectId).Select(p => new GetProjectDto
            {
                Id = p.Id,
                Name = p.Name,
                DeliveryDate = p.DeliveryDate

            }).FirstOrDefaultAsync();
        }

        public async Task<int> UpdateProject(UpdateProjectDto updateProjectDto)
        {
            var currentProject = await _ozbelsanDbContext.Projects.Where(p => !p.IsDeleted && p.Id == updateProjectDto.Id).FirstOrDefaultAsync();
            if (currentProject == null)
            {
                return -1;
            }
            currentProject.Name = updateProjectDto.Name;   
            currentProject.DeliveryDate = updateProjectDto.DeliveryDate;

            _ozbelsanDbContext.Projects.Update(currentProject);
            return await _ozbelsanDbContext.SaveChangesAsync();
        }
    }
}
