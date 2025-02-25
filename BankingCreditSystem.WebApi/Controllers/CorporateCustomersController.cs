using BankingCreditSystem.Application.Features.CorporateCustomers.Commands.Create;
using BankingCreditSystem.Application.Features.CorporateCustomers.Commands.Delete;
using BankingCreditSystem.Application.Features.CorporateCustomers.Commands.Update;
using BankingCreditSystem.Application.Features.CorporateCustomers.Queries.GetById;
using BankingCreditSystem.Application.Features.CorporateCustomers.Queries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace BankingCreditSystem.WebApi.Controllers
{
    public class CorporateCustomersController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListCorporateCustomerQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCorporateCustomerQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCorporateCustomerCommand command)
        {
            var result = await Mediator.Send(command);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCorporateCustomerCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCorporateCustomerCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
} 