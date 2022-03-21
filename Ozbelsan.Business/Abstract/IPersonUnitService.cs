using Ozbelsan.DAL.Dto.PersonUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozbelsan.Business.Abstract
{
   public interface IPersonUnitService
    {
        Task<List<GetListPersonUnitDto>> GetAllPersonUnit();
        Task<GetPersonUnitDto> GetPersonUnitById(int PersonUnitId);
        Task<int> AddPersonUnit(AddPersonUnitDto addPersonUnitDto);
        Task<int> UpdatePersonUnit(UpdatePersonUnitDto updatePersonUnitDto);
        Task<int> DeletePersonUnit(int PersonUnitId);
    }
}
