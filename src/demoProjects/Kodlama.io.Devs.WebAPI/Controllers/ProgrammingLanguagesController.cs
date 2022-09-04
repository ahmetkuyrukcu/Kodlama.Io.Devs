using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProgrammingLanguagesController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        return Ok(await Mediator.Send(new GetListProgrammingLanguageQuery { PageRequest = pageRequest }));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        return Ok(await Mediator.Send(new GetByIdProgrammingLanguageQuery { Id = id }));
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] ProgrammingLanguageCommand programmingLanguageCommand)
    {
        return Created("", await Mediator.Send(programmingLanguageCommand));
    }
}