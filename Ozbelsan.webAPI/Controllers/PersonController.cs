using Microsoft.AspNetCore.Mvc;
using Ozbelsan.Business.Abstract;
using Ozbelsan.Business.Validation.Person;
using Ozbelsan.DAL.Dto.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Ozbelsan.webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        [HttpGet]
        [Route("GetPersonList")]

        public async Task<ActionResult<List<GetListPersonDto>>> GetPersonList()
        {
            try
            {
                return Ok(await _personService.GetAllPersons());
            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }
        }
        [HttpGet]
        [Route("GetPersonById/{id:int}")]

        public async Task<ActionResult<GetPersonDto>> GetPerson(int id)
        {
            var list = new List<String>();
            if (id <= 0)
            {
                list.Add("Person ID gecersiz");
                return Ok(new { code = StatusCode(1001), message = list, type = "error" });
            }
            try
            {
                var currentPerson = await _personService.GetPersonById(id);
                if (currentPerson == null)
                {
                    list.Add("Person Bulunamadı");
                    return Ok(new { code = StatusCode(1001), message = list, type = " error" });

                }
                else
                {
                    return currentPerson;
                }

            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }

        }
        [HttpPost("AddPerson")]
        public async Task<ActionResult<string>> AddPersonDto(AddPersonDto addPersonDto)
        {
            var list = new List<string>();

            var validator = new AddPersonValidator();
            var validationResults = validator.Validate(addPersonDto); // kontrol etmeyi sağlayan method

            if(!validationResults.IsValid) // IsValid geçerli birşey gelmediyse bunları foreachler sırayla hepsini kontrol ederek errors(error.ErrorMessage) adı altında toplar.
            {
                foreach (var error in validationResults.Errors)
                {
                    list.Add(error.ErrorMessage);
                }
                return Ok(new { code = StatusCode(1002), message = list, type = "error" });
            }

            try
            {
                var result = await _personService.AddPerson(addPersonDto);

                if (result > 0)
                {
                    list.Add("EKLEME ISLEMI BASARILI");
                    return Ok(new { code = StatusCode(1000), message = list, type = "succcess" });
                }
                else
                {
                    list.Add("EKLEME ISLEMI BASARISIZ.");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }
        }

        [HttpPut]
        [Route("UpdatePerson")]
        public async Task<ActionResult<string>> UpdatePerson(UpdatePersonDto updatePersonDto)
        {
            var list = new List<string>();

            var validator = new UpdatePersonValidator();
            var validationResults = validator.Validate(updatePersonDto);

            if (!validationResults.IsValid)
            {
                foreach (var error in validationResults.Errors)
                {
                    list.Add(error.ErrorMessage);
                }
                return Ok(new { code = StatusCode(1002), message = list, type = "error" });
            }

            try
            {
                var result = await _personService.UpdatePerson(updatePersonDto);
                if (result > 0)
                {
                    list.Add("GUNCELLEME BASARILI");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else if (result == -1)
                {
                    list.Add("ID BOŞ");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });

                }
                else
                {
                    list.Add("GUNCELLEME BASARISIZ");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }

            }
            catch (Exception hata)
            {
                return BadRequest(hata.Message);
            }
        }

        [HttpDelete]
        [Route("DeletePerson/{id:int}")]
        public async Task<ActionResult<string>> DeletePerson(int id)
        {
            var list = new List<string>();
            try
            {
                var result = await _personService.DeletePerson(id);
                if (result <= 0)
                {
                    list.Add("Silme işlemi başarısız");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });

                }
                else if (result == -1)
                {
                    list.Add("Silinecek id bulunamadı");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    list.Add("Silme işlemi başarılı");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }

            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }
        }

    }

}
