using Microsoft.AspNetCore.Mvc;
using Ozbelsan.Business.Abstract;
using Ozbelsan.Business.Validation.Project;
using Ozbelsan.DAL.Dto.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozbelsan.webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        [HttpGet]
        [Route("GetProjectList")]
        public async Task<ActionResult<List<GetListProjectDto>>> GetProjectList()
        {
            try
            {
                return Ok(await _projectService.GetAllProjects());
            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }
        }
        [HttpGet]
        [Route("GetProjectById/{id:int}")]
        public async Task<ActionResult<GetProjectDto>> GetProject(int id)
        {
            var list = new List<string>();
            if (id <= 0)
            {
                list.Add("Gecersız project ıd girdiniz ");
                return Ok(new { code = StatusCode(1001), Message = list, type = "error" });
            }
            try
            {
                var currentProject = await _projectService.GetProjectById(id);
                if (currentProject == null)
                {
                    list.Add("Project Bulunamadı");
                    return Ok(new { code = StatusCode(1001), message = list, type = " error" });

                }
                else
                {
                    return currentProject;
                }

            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }
        }
        [HttpPost("AddProject")]
        public async Task<ActionResult<string>> AddProjectDto(AddProjectDto addProjectDto)
        {
            var list = new List<string>();

            var Validator = new AddProjectValidator();
            var validationResult = Validator.Validate(addProjectDto);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {

                    list.Add(error.ErrorMessage);

                }
                return Ok(new { code = StatusCode(1002), message = list, type = "error" });
            }


            try
            {
                var result = await _projectService.AddProject(addProjectDto);

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
        [Route("UpdateProject")]
        public async Task<ActionResult<string>> UpdateProject(UpdateProjectDto updateProjectDto)
        {
            var list = new List<string>();
            var validator = new UpdateProjectValidator();
            var validatonResults = validator.Validate(updateProjectDto);
            if (!validatonResults.IsValid)
            {
                foreach (var error in validatonResults.Errors)
                {
                    list.Add(error.ErrorMessage);
                }
                return Ok(new { code = StatusCode(1002), message = list, type = "error" });
            }
            try
            {
                var result = await _projectService.UpdateProject(updateProjectDto);
                if (result > 0)
                {
                    list.Add("GUNCELLEME BASARILI");
                    return Ok(new { code = StatusCode(1000), message = list, type = "succes" });
                }
                else if (result == -1)
                {
                    list.Add("BOYLE BI ID BULUNAMADI");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    list.Add("Guncelleme basarısız");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }

            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }
        }
        [HttpDelete]
        [Route("DeleteProject/{id:int}")]

        public async Task<ActionResult<string>> DeleteProject(int id)
        {
            var list = new List<string>();
            try
            {
                var result = await _projectService.DeleteProject(id);
                if (result > 0)
                {
                    list.Add("Silme işlemi başarılı");
                    return Ok(new { code = StatusCode(1000), message = list, type = "error" });
                }
                else if (result == -1)
                {
                    list.Add("Silinecek bi id bulunamadı");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    list.Add("Silme işlemi başarısız");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }
        }
    }
}
