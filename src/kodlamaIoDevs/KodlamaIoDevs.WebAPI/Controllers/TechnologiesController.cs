using Core.Application.Requests;
using KodlamaIoDevs.Application.Features.Technology.Commands.CreateTechnology;
using KodlamaIoDevs.Application.Features.Technology.Commands.DeleteTechnology;
using KodlamaIoDevs.Application.Features.Technology.Commands.UpdateTechnology;
using KodlamaIoDevs.Application.Features.Technology.Queries.GetListTecnology;
using Microsoft.AspNetCore.Mvc;

namespace KodlamaIoDevs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologiesController: BaseController
    {
        [HttpGet(nameof(GetList))]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var getTechnologyListQuery = new GetListTechnologyQuery() { PageRequest = pageRequest };
            var result = await Mediator!.Send(getTechnologyListQuery);
            return Ok(result);
        }

        [HttpPost(nameof(Add))]
        public async Task<IActionResult> Add([FromBody] CreateTechnologyCommand createTechnologyCommand)
        {
            var result = await Mediator!.Send(createTechnologyCommand);
            return Created("", result);
        }

        // Todo: update is not working !!
        [HttpPut(nameof(Update))]
        public async Task<IActionResult> Update([FromBody] UpdateTechnologyCommand updateTechnologyCommand)
        {
            var result = await Mediator!.Send(updateTechnologyCommand);
            return NoContent();
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteTechnologyCommand deleteTechnologyCommand)
        {
            var result = await Mediator!.Send(deleteTechnologyCommand);
            return NoContent();
        }
    }
}
