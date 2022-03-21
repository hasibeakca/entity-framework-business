using Microsoft.AspNetCore.Mvc;
using Ozbelsan.Business.Abstract;
using Ozbelsan.Business.Validation.ProjectPerson;
using Ozbelsan.DAL.Dto.ProjectPerson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozbelsan.webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectPersonController : ControllerBase
    {
        private readonly IProjectPersonService _projectPersonService;
        public ProjectPersonController(IProjectPersonService projectPersonService)
        {
            _projectPersonService = projectPersonService;
        }
        [HttpGet]
        [Route("GetProjectPersonList")]
        public async Task<ActionResult<List<GetListProjectPersonDto>>> GetProjectPersonList()
        {
            try
            {
                return Ok(await _projectPersonService.GetAllProjectPersons());
            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }
        }
        [HttpGet]
        [Route("GetProjectPersonById/{id:int}")]
        public async Task<ActionResult<GetProjectPersonDto>> GetProjectPerson(int id)
        {
            var list = new List<string>();
            if (id <= 0)
            {
                list.Add("Gecersız projectperson ıd girdiniz ");
                return Ok(new { code = StatusCode(1001), Message = list, type = "error" });
            }
            try
            {
                var currentProjectPerson = await _projectPersonService.GetProjectPersonById(id);
                if(currentProjectPerson == null)
                {
                    list.Add("ProjectPerson Bulunamadı");
                    return Ok(new { code = StatusCode(1001), message = list, type = " error" });

                }
                else
                {
                    return currentProjectPerson;
                }

            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }
        }
        [HttpPost("AddProjectPerson")]
        public async Task<ActionResult<string>> AddProjectPersonDto(AddProjectPersonDto addProjectPersonDto)
        {
            var list = new List<string>();
            var Validator = new AddProjectPersonValidator();
            var validationResults = Validator.Validate(addProjectPersonDto);
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
                var result = await _projectPersonService.AddProjectPerson(addProjectPersonDto);

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
        [Route("UpdateProjectPerson")]
        public async Task<ActionResult<string>> UpdateProjectPerson(UpdateProjectPersonDto updateProjectPersonDto)
        {
            var list = new List<string>();
            var Validator = new UpdateProjectPersonValidator();
            var validationResults = Validator.Validate(updateProjectPersonDto);
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
                var result = await _projectPersonService.UpdateProjectPerson(updateProjectPersonDto);
                if (result <= 0)
                {
                    list.Add("Guncelleme basarısız");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else if (result == -1)
                {
                    list.Add("BOYLE BI ID BULUNAMADI");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    list.Add("GUNCELLEME BASARILI");
                    return Ok(new { code = StatusCode(1000), message = list, type = "succes" });
                }

            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }
        }
        [HttpDelete]
        [Route("DeleteProjectPerson/{id:int}")]

        public async Task<ActionResult<string>> DeleteProjectPerson(int id)
        {
            var list = new List<string>();
            try
            {
                var result = await _projectPersonService.DeleteProjectPerson(id);
                if (result <= 0)
                {
                    list.Add("Silme işlemi başarısız");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else if (result == -1)
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
