using Core.Application.Requests;
using KodlamaIoDevs.Application.Features.SocialMedia.Commands.CreateSocialMedia;
using KodlamaIoDevs.Application.Features.SocialMedia.Commands.DeleteSocialMedia;
using KodlamaIoDevs.Application.Features.SocialMedia.Commands.UpdateSocialMedia;
using KodlamaIoDevs.Application.Features.SocialMedia.Queries.GetListSocialMedia;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KodlamaIoDevs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : BaseController
    {
        [HttpPost(nameof(Add))]
        public async Task<IActionResult> Add([FromBody] CreateSocialMediaCommand createSocialMediaCommand)
        {
            var result = await Mediator!.Send(createSocialMediaCommand);

            return Created("", result);
        }

        [HttpGet(nameof(GetList))]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var getSocialMediaQuery = new GetListSocialMediaQuery() { PageRequest = pageRequest };
            var result = await Mediator!.Send(getSocialMediaQuery);
            return Ok(result);
        }

        [HttpPut(nameof(Update))]
        public async Task<IActionResult> Update([FromBody] UpdateSocialMediaCommand updateSocialMediaCommand)
        {
            var result = await Mediator!.Send(updateSocialMediaCommand);

            return Ok(result);
        }


        /// Todo: Silme tam olarak çalısmıyor. Düzeltilecek.
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteSocialMediaCommand deleteSocialMediaCommand)
        {
            var result = await Mediator!.Send(deleteSocialMediaCommand);
            return NoContent();
        }

    }
}
