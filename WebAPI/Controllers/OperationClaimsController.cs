using Application.Features.OperaionClaims.Commands.CreateOperationClaims;
using Application.Features.OperaionClaims.Commands.DeleteOperationClaim;
using Application.Features.OperaionClaims.Commands.UpdateOperationClaim;
using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Models;
using Application.Features.OperationClaims.Queries.GetListOperationClaim;
using Core.Application.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : BaseController
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] CreateOperationClaimCommand createOperationClaimCommand)
        {
            CreatedOperationClaimDto createdOperationClaimDto = await Mediator.Send(createOperationClaimCommand);
            return Created("", createdOperationClaimDto);
        }


        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateOperationClaimCommand updateOperationClaimCommand)
        {
            UpdatedOperationClaimDto updatedOperationClaimDto = await Mediator.Send(updateOperationClaimCommand);
            return Created("", updatedOperationClaimDto);
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete([FromBody] DeleteOperationClaimCommand deleteOperationClaimCommand)
        {
            DeletedOperationClaimDto deletedOperationClaimDto = await Mediator.Send(deleteOperationClaimCommand);
            return Created("", deletedOperationClaimDto);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListOperationClaimQuery getListOperationClaimQuery = new() { PageRequest = pageRequest };
            OperationClaimListModel result = await Mediator.Send(getListOperationClaimQuery);
            return Ok(result);
        }
    }
}
