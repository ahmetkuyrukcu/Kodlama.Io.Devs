using Core.Application.Requests;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.Io.Devs.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProgrammingLanguagesController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        return Ok(await Mediator.Send(new GetListProgrammingLanguageQuery { PageRequest = pageRequest }));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        return Ok(await Mediator.Send(new GetByIdProgrammingLanguageQuery { Id = id }));
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand programmingLanguageCommand)
    {
        return Created(string.Empty, await Mediator.Send(programmingLanguageCommand));
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageCommand programmingLanguageCommand)
    {
        return Ok(await Mediator.Send(programmingLanguageCommand));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await Mediator.Send(new DeleteProgrammingLanguageCommand { Id = id });

        return NoContent();
    }
}