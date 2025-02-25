using AutoMapper;
using BankingCreditSystem.Application.Features.CorporateCustomers.Constants;
using BankingCreditSystem.Application.Features.CorporateCustomers.DTOs.Requests;
using BankingCreditSystem.Application.Features.CorporateCustomers.DTOs.Responses;
using BankingCreditSystem.Application.Features.CorporateCustomers.Rules;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Domain.Entities;
using MediatR;

namespace BankingCreditSystem.Application.Features.CorporateCustomers.Commands.Create
{
    public class CreateCorporateCustomerCommand : IRequest<CreateCorporateCustomerResponse>
    {
        public CreateCorporateCustomerRequest Request { get; set; } = default!;

        public class CreateCorporateCustomerCommandHandler : IRequestHandler<CreateCorporateCustomerCommand, CreateCorporateCustomerResponse>
        {
            private readonly ICorporateCustomerRepository _corporateCustomerRepository;
            private readonly IMapper _mapper;
            private readonly CorporateCustomerBusinessRules _businessRules;

            public CreateCorporateCustomerCommandHandler(
                ICorporateCustomerRepository corporateCustomerRepository,
                IMapper mapper,
                CorporateCustomerBusinessRules businessRules)
            {
                _corporateCustomerRepository = corporateCustomerRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<CreateCorporateCustomerResponse> Handle(CreateCorporateCustomerCommand command, CancellationToken cancellationToken)
            {
                await _businessRules.TaxNumberCannotBeDuplicatedWhenInserted(command.Request.TaxNumber);
                await _businessRules.TaxNumberValidation(command.Request.TaxNumber);
                await _businessRules.EmailValidation(command.Request.Email);
                //await _businessRules.PhoneNumberValidation(command.Request.PhoneNumber);

                var corporateCustomer = _mapper.Map<CorporateCustomer>(command.Request);
                var createdCustomer = await _corporateCustomerRepository.AddAsync(corporateCustomer);

                var response = _mapper.Map<CreateCorporateCustomerResponse>(createdCustomer);
                response.Message = CorporateCustomerMessages.CustomerCreated;

                return response;
            }
        }
    }
} 