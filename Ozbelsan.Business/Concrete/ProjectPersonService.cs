using Microsoft.EntityFrameworkCore;
using Ozbelsan.Business.Abstract;
using Ozbelsan.DAL.Context;
using Ozbelsan.DAL.Dto.ProjectPerson;
using Ozbelsan.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozbelsan.Business.Concrete
{
    public class ProjectPersonService : IProjectPersonService
    {
        private readonly OzbelsanDbContext _ozbelsanDbContext;

        public ProjectPersonService(OzbelsanDbContext ozbelsanDbContext)
        {
            _ozbelsanDbContext = ozbelsanDbContext;
        }

        public async Task<int> AddProjectPerson(AddProjectPersonDto addProjectPersonDto)
        {
            var addingProjectPerson = new ProjectPerson
            {
                PersonId = addProjectPersonDto.PersonId,
                ProjectId = addProjectPersonDto.ProjectId
            };
           await _ozbelsanDbContext.ProjectPersons.AddAsync(addingProjectPerson);
            return await _ozbelsanDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteProjectPerson(int projectPersonId)
        {
            var currentProjectPerson = await _ozbelsanDbContext.ProjectPersons.Where(p => !p.IsDeleted && p.Id == projectPersonId).FirstOrDefaultAsync();
            if (currentProjectPerson == null)
            {
                return -1;
            }
            currentProjectPerson.IsDeleted = true; // once sılınıp sılınmedıgını ekrana gostreıyoruz 
            _ozbelsanDbContext.ProjectPersons.Update(currentProjectPerson); //gunvellemesını belırtıyoruz 
            return await _ozbelsanDbContext.SaveChangesAsync(); // SaveChanges de return demek kac satır duzenledıgını gosterır
        }

        public async Task<List<GetListProjectPersonDto>> GetAllProjectPersons()
        {
            return await _ozbelsanDbContext.ProjectPersons.Include(p
                => p.ProjectFK).Include(p => p.PersonFK)
                .Where(p => !p.IsDeleted).Select(p => new GetListProjectPersonDto
                {
                    ProjectName = p.ProjectFK.Name,
                    PersonName = p.PersonFK.Name,
                    PersonSurname = p.PersonFK.Surname,
                    PersonNumber = p.PersonFK.PersonNumber
                }).ToListAsync();
        }

        public async Task<GetProjectPersonDto> GetProjectPersonById(int projectPersonId)
        {
            return await _ozbelsanDbContext.ProjectPersons.Include(p => p.ProjectFK).Include(p => p.PersonFK)
                .Where(p => !p.IsDeleted && p.Id == projectPersonId).Select(p => new GetProjectPersonDto
                {
                    ProjectName = p.ProjectFK.Name,
                    PersonName = p.PersonFK.Name,
                    PersonSurname = p.PersonFK.Surname,
                    PersonNumber = p.PersonFK.PersonNumber
                }).FirstOrDefaultAsync();
        }

        public async Task<int> UpdateProjectPerson(UpdateProjectPersonDto updateProjectPersonDto)
        {
            var currentProjectPerson = await _ozbelsanDbContext.ProjectPersons.Where(p => !p.IsDeleted && p.Id == updateProjectPersonDto.Id).FirstOrDefaultAsync();
            if (currentProjectPerson == null)
            {
                return -1;
            }
            currentProjectPerson.PersonId = updateProjectPersonDto.PersonId;
            currentProjectPerson.ProjectId = updateProjectPersonDto.ProjectId;
            _ozbelsanDbContext.ProjectPersons.Update(currentProjectPerson);
            return await _ozbelsanDbContext.SaveChangesAsync();
        }
    }
}
