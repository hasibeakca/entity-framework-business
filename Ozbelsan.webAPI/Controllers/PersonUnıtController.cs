using Microsoft.AspNetCore.Mvc;
using Ozbelsan.Business.Abstract;
using Ozbelsan.Business.Validation.PersonUnit;
using Ozbelsan.DAL.Dto.PersonUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozbelsan.webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonUnıtController : ControllerBase
    {
        private readonly IPersonUnitService _personUnitService;
        public PersonUnıtController (IPersonUnitService personUnitService)
        {
            _personUnitService = personUnitService;
        }
        [HttpGet]
        [Route("GetPersonUnit")]
        public async Task<ActionResult<List<GetListPersonUnitDto>>> GetPersonUnitList()
        {
            try
            {
                return Ok(await _personUnitService.GetAllPersonUnit());

            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }
        }
        [HttpGet]
        [Route("GetPersonUnitById/{id:int}")]
        public async Task<ActionResult<GetPersonUnitDto>> GetPersonUnit(int id)
        {
            var list = new List<string>();
            if (id <= 0)
            {
                list.Add("GEÇERSİZ PERSONUNIT ID Sİ GİRDİNİZ.");
                return Ok(new { code = StatusCode(1001), message = list, type = "errror" });

            }
            try
            {
                var currentPersonUnit = await _personUnitService.GetPersonUnitById(id);
                if (currentPersonUnit  == null)
                {
                    list.Add("PersonUnit Bulunamadı");
                    return Ok(new { code = StatusCode(1001), message = list, type = " error" });

                }
                else
                {
                    return currentPersonUnit;
                }

            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }

        }
        [HttpPost("AddPersonUnit")]
        public async Task<ActionResult<string>> AddPersonUnitDto(AddPersonUnitDto addPersonUnitDto)
        {
            var list = new List<string>();
            var Validator = new AddPersonUnitValidator();
            var validationResults = Validator.Validate(addPersonUnitDto);
            if(!validationResults.IsValid)
            {
                foreach(var error in validationResults.Errors)
                {
                    list.Add(error.ErrorMessage);
                }
                return Ok(new { code = StatusCode(1002), message = list, type = "error" });
            }
            try
            {
                var result = await _personUnitService.AddPersonUnit(addPersonUnitDto);

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
        [Route("UpdatePersonUnit")]
        public async Task<ActionResult<string>> UpdatePersonUnit(UpdatePersonUnitDto updatePersonUnitDto)
        {
            var list = new List<string>();
            var validator = new UpdatePersonUnitValidator();
            var validationResults = validator.Validate(updatePersonUnitDto);

            if (!validationResults.IsValid)
            {
                foreach(var error in validationResults.Errors)
                {
                    list.Add(error.ErrorMessage);
                }
                return Ok(new { code = StatusCode(1002), message = list, type = "error" });
            }


            try
            {
                var result = await _personUnitService.UpdatePersonUnit(updatePersonUnitDto);
                if(result<= 0)
                {
                    list.Add("Guncelleme basarısız");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }else if(result == -1)
                {
                    list.Add("PERSONUNIT ID BULUNAMADI");
                    return Ok(new { code = StatusCode(1000), message = list, type = "error" });
                }
                else
                {
                    list.Add("Guncelleme basarılı");
                    return Ok(new { code = StatusCode(1000), message = list, type = "error" });
                }
                

            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }
        }
        [HttpDelete]
        [Route("DeletePersonUnit/{id:int}")]

        public async Task<ActionResult<string>> DeletePersonUnit(int id)
        {
            var list = new List<string>();
            try
            {
                var result = await _personUnitService.DeletePersonUnit(id);
                if (result <= 0)
                {
                    list.Add("Silme işlemi başarısız");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }else if( result== -1)
                {
                    list.Add("Silinecek bi id bulunamadı");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    list.Add("Silme işlemi başarılı");
                    return Ok(new { code = StatusCode(1000), message = list, type = "error" });

                }
            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }
        }

    }
}
