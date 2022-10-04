using Core.Application.Requests;
using Kodlama.Io.Devs.Application.Features.Technologies.Commands.CreateTechnology;
using Kodlama.Io.Devs.Application.Features.Technologies.Commands.DeleteTechnology;
using Kodlama.Io.Devs.Application.Features.Technologies.Commands.UpdateTechnology;
using Kodlama.Io.Devs.Application.Features.Technologies.Queries.GetByIdTechnology;
using Kodlama.Io.Devs.Application.Features.Technologies.Queries.GetListTechnology;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.Io.Devs.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TechnologiesController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        return Ok(await Mediator.Send(new GetListTechnologyQuery { PageRequest = pageRequest }));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        return Ok(await Mediator.Send(new GetByIdTechnologyQuery { Id = id }));
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateTechnologyCommand technologyCommand)
    {
        return Created(new Uri("about:blank"), await Mediator.Send(technologyCommand));
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateTechnologyCommand technologyCommand)
    {
        return Ok(await Mediator.Send(technologyCommand));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await Mediator.Send(new DeleteTechnologyCommand { Id = id });

        return NoContent();
    }
}