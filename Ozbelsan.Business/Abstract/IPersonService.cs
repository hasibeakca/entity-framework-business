using Ozbelsan.DAL.Dto.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozbelsan.Business.Abstract
{
   public interface IPersonService 
    {

        Task<List<GetListPersonDto>> GetAllPersons();

        Task<GetPersonDto> GetPersonById(int PersonId);

        Task<int> AddPerson(AddPersonDto addPersonDto);
        Task<int> UpdatePerson(UpdatePersonDto updatePersonDto);

        Task<int> DeletePerson(int PersonId);
    }
}
