using Microsoft.EntityFrameworkCore;
using Ozbelsan.Business.Abstract;
using Ozbelsan.DAL.Context;
using Ozbelsan.DAL.Dto.PersonUnit;
using Ozbelsan.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Entity;

namespace Ozbelsan.Business.Concrete
{
    public class PersonUnitService : IPersonUnitService
    {
        private readonly OzbelsanDbContext _ozbelsanDbContext;

        public PersonUnitService(OzbelsanDbContext ozbelsanDbContext)
        {
            _ozbelsanDbContext = ozbelsanDbContext;
        }



        public async Task<int> AddPersonUnit(AddPersonUnitDto addPersonUnitDto)
        {
            var AddingPersonUnit = new PersonUnit
            {
                UnitName = addPersonUnitDto.UnitName,
                Department = addPersonUnitDto.Department,
                PersonelNumber = addPersonUnitDto.PersonelNumber,


            };
           await _ozbelsanDbContext.PersonUnits.AddAsync(AddingPersonUnit);
            return await _ozbelsanDbContext.SaveChangesAsync();
        }

        public async Task<int> DeletePersonUnit(int PersonUnitId)
        {
            var CurrentPersonUnit = await _ozbelsanDbContext.PersonUnits.Where(p => !p.IsDeleted && p.Id == PersonUnitId).FirstOrDefaultAsync();
            if (CurrentPersonUnit == null)
            {
                return -1;

            }
            CurrentPersonUnit.IsDeleted = true;
            _ozbelsanDbContext.PersonUnits.Update(CurrentPersonUnit);
            return await _ozbelsanDbContext.SaveChangesAsync();

        }

        public async Task< List<GetListPersonUnitDto>> GetAllPersonUnit()
        {
            return await _ozbelsanDbContext.PersonUnits.Where(p => !p.IsDeleted).Select(p => new GetListPersonUnitDto
            {
                Id = p.Id,
                Department = p.Department,
                UnitName = p.UnitName,
                PersonelNumber = p.PersonelNumber

            }).ToListAsync();

        }

        public async Task< GetPersonUnitDto> GetPersonUnitById(int PersonUnitId)
        {
            return await _ozbelsanDbContext.PersonUnits.Where(p => !p.IsDeleted && p.Id == PersonUnitId).Select(p => new GetPersonUnitDto
            {
                Id = p.Id,
                UnitName = p.UnitName,
                Department = p.Department,
                PersonelNumber = p.PersonelNumber

            }).FirstOrDefaultAsync();
        }

        public async Task<int> UpdatePersonUnit(UpdatePersonUnitDto updatePersonUnitDto)
        {
            var CurrentPersonUnit = await _ozbelsanDbContext.PersonUnits.Where(p => !p.IsDeleted && p.Id == updatePersonUnitDto.Id).FirstOrDefaultAsync();
            if (CurrentPersonUnit == null)
            {
                return -1;

            }
         
            CurrentPersonUnit.UnitName = updatePersonUnitDto.UnitName;
            CurrentPersonUnit.PersonelNumber = updatePersonUnitDto.PersonelNumber;
            CurrentPersonUnit.Department = updatePersonUnitDto.Department;


            _ozbelsanDbContext.PersonUnits.Update(CurrentPersonUnit);
            return await _ozbelsanDbContext.SaveChangesAsync();
        }
    }
}
