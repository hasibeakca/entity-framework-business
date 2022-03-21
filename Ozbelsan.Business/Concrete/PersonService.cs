using AppCore.Entity;
using Microsoft.EntityFrameworkCore;
using Ozbelsan.Business.Abstract;
using Ozbelsan.DAL.Context;
using Ozbelsan.DAL.Dto.Person;
using Ozbelsan.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozbelsan.Business.Concrete
{
    public class PersonService : IPersonService
    {
        private readonly OzbelsanDbContext _ozbelsanDbContext;

        public PersonService(OzbelsanDbContext ozbelsanDbContext)
        {
            _ozbelsanDbContext = ozbelsanDbContext;
        }

        public async Task<int> AddPerson(AddPersonDto addPersonDto)
        {
            var AddingPerson = new Person
            {
                Name = addPersonDto.Name,
                Surname = addPersonDto.Surname,
                PersonNumber = addPersonDto.PersonNumber,
                PersonUnitId = addPersonDto.PersonUnitId
            };
            await _ozbelsanDbContext.Persons.AddAsync(AddingPerson);
            return await _ozbelsanDbContext.SaveChangesAsync();
        }

        public async Task<int> DeletePerson(int PersonId)
        {
            var CurrentPerson = await _ozbelsanDbContext.Persons.Where(p => !p.IsDeleted && p.Id == PersonId).FirstOrDefaultAsync();
            if (CurrentPerson == null)
            {
                return -1;

            }
            CurrentPerson.IsDeleted = true;
            _ozbelsanDbContext.Persons.Update(CurrentPerson);
            return await _ozbelsanDbContext.SaveChangesAsync();
        }

        public async Task<List<GetListPersonDto>> GetAllPersons()
        {
            return await _ozbelsanDbContext.Persons.Where(p => !p.IsDeleted).Include(p => p.PersonUnitFK)
                .Select(p => new GetListPersonDto  //TEK BIR TANE ISTEMEDIGIMIZ ICIN ID SINI ISTEMEDIK
                {
                    Id = p.Id,
                    Name = p.Name,
                    Surname = p.Surname,
                    PersonNumber = p.PersonNumber,
                    PersonUnitId = p.PersonUnitId,
                    UnitName = p.PersonUnitFK.UnitName
                }).ToListAsync();
        }

        public async Task<GetPersonDto> GetPersonById(int PersonId)
        {
            return await _ozbelsanDbContext.Persons.Where(p => !p.IsDeleted && p.Id == PersonId).Include(p => p.PersonUnitFK).Select(p => new GetPersonDto
            {
                Id = p.Id,
                Name = p.Name,
                Surname = p.Surname,
                PersonNumber = p.PersonNumber,
                PersonUnitId = p.PersonUnitId,
                UnitName = p.PersonUnitFK.UnitName
            }).FirstOrDefaultAsync();
        }

        public async Task<int> UpdatePerson(UpdatePersonDto updatePersonDto)
        {
            var currentPerson = await _ozbelsanDbContext.Persons.Where(p => !p.IsDeleted && p.Id == updatePersonDto.Id).FirstOrDefaultAsync();
            if (currentPerson == null)
            {
                return -1;
            }
            currentPerson.Name = updatePersonDto.Name;
            currentPerson.Surname = updatePersonDto.Surname;
            currentPerson.PersonNumber = updatePersonDto.PersonNumber;
            currentPerson.PersonUnitId = updatePersonDto.PersonUnitId;

            _ozbelsanDbContext.Persons.Update(currentPerson);
            return await _ozbelsanDbContext.SaveChangesAsync();

        }
    }
}
