using Core.Application.Requests;
using KodlamaIoDevs.Application.Features.ProgrammingLanguage.Commands.CreateProgrammingLanguage;
using KodlamaIoDevs.Application.Features.ProgrammingLanguage.Commands.DeleteProgrammingLanguage;
using KodlamaIoDevs.Application.Features.ProgrammingLanguage.Commands.UpdateProgrammingLanguage;
using KodlamaIoDevs.Application.Features.ProgrammingLanguage.Queries.GetByIdProgrammingLanguage;
using KodlamaIoDevs.Application.Features.ProgrammingLanguage.Queries.GetListProgrammingLanguage;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KodlamaIoDevs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController:BaseController
    {
        [HttpPost(nameof(Add))]
        public async Task<IActionResult> Add([FromBody]CreateProgrammingLanguageCommand createProgrammingLanguageCommand)
        {
            var result = await Mediator!.Send(createProgrammingLanguageCommand);

            return Created("",result);
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute]DeleteProgrammingLanguageCommand deleteProgrammingLanguageCommand)
        {
            var result=await Mediator!.Send(deleteProgrammingLanguageCommand);
            return NoContent();
        }

        [HttpPut(nameof(Update))]
        public async Task<IActionResult> Update([FromBody]UpdateProgrammingLanguageCommand updateProgrammingLanguageCommand)
        {
            var result = await Mediator!.Send(updateProgrammingLanguageCommand);
            return NoContent();
        }
        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetByID([FromRoute]GetByIdProgrammingLanguageQuery getByIdProgrammingLanguageQuery)
        {
            var result =await Mediator!.Send(getByIdProgrammingLanguageQuery);
            return Ok(result);
        }
        [HttpGet(nameof(GetList))]
        public async Task<IActionResult> GetList([FromQuery]PageRequest pageRequest)
        {
            var getProgrammingLanguageQuery = new GetListProgrammingLanguageQuery()
            {
                PageRequest = pageRequest
            };
            var result=await Mediator!.Send(getProgrammingLanguageQuery);
            return Ok(result);
        }
    }
}
