using Application.Features.SoftwareTechs.Commands.CreateSoftwareTech;
using Application.Features.SoftwareTechs.Commands.DeleteSoftwareTech;
using Application.Features.SoftwareTechs.Commands.UpdateSoftwareTech;
using Application.Features.SoftwareTechs.Dtos;
using Application.Features.SoftwareTechs.Models;
using Application.Features.SoftwareTechs.Queries.GetByIdSoftwareTech;
using Application.Features.SoftwareTechs.Queries.GetListSoftwareTech;
using Core.Application.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SoftwareTechsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSoftwareTechCommand createSoftwareTechCommand)
        {
            CreatedSoftwareTechDto result = await Mediator!.Send(createSoftwareTechCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSoftwareTechCommand updateSoftwareTechCommand)
        {
            UpdatedSoftwareTechDto result = await Mediator!.Send(updateSoftwareTechCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteSoftwareTechCommand deleteSoftwareTechCommand)
        {
            DeletedSoftwareTechDto result = await Mediator!.Send(deleteSoftwareTechCommand);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListSoftwareTechQuery getListSoftwareTechQuery = new() { PageRequest = pageRequest };
            SoftwareTechListModel result = await Mediator!.Send(getListSoftwareTechQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdSoftwareTechQuery getByIdSoftwareTechQuery)
        {
            SoftwareTechGetByIdDto softwareTechGetByIdDto = await Mediator!.Send(getByIdSoftwareTechQuery);
            return Ok(softwareTechGetByIdDto);
        }
    }
}
