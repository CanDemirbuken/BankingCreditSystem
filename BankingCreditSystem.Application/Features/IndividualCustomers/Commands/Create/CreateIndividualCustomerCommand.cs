using AutoMapper;
using BankingCreditSystem.Application.Features.IndividualCustomers.DTOs.Requests;
using BankingCreditSystem.Application.Features.IndividualCustomers.Rules;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Core.Security.Hashing;
using BankingCreditSystem.Domain.Entities;
using MediatR;

namespace BankingCreditSystem.Application.Features.IndividualCustomers.Commands.Create
{
    public class CreateIndividualCustomerCommand : IRequest<CreateIndividualCustomerResponse>
    {
        public CreateIndividualCustomerRequest Request { get; set; } = default!;

        public class CreateIndividualCustomerCommandHandler : IRequestHandler<CreateIndividualCustomerCommand, CreateIndividualCustomerResponse>
        {
            private readonly IIndividualCustomerRepository _individualCustomerRepository;
            private readonly IndividualCustomerBusinessRules _businessRules;
            private readonly IMapper _mapper;
            private readonly IHashingHelper _hashingHelper;

            public CreateIndividualCustomerCommandHandler(
                IIndividualCustomerRepository individualCustomerRepository,
                IndividualCustomerBusinessRules businessRules,
                IMapper mapper,
                IHashingHelper hashingHelper)
            {
                _individualCustomerRepository = individualCustomerRepository;
                _businessRules = businessRules;
                _mapper = mapper;
                _hashingHelper = hashingHelper;
            }

            public async Task<CreateIndividualCustomerResponse> Handle(CreateIndividualCustomerCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.NationalIdCannotBeDuplicatedWhenInserted(request.Request.NationalId);

                byte[] passwordHash, passwordSalt;
                _hashingHelper.CreatePasswordHash(request.Request.Password, out passwordHash, out passwordSalt);

                var applicationUser = new ApplicationUser
                {
                    Email = request.Request.Email,
                    PhoneNumber = request.Request.PhoneNumber,
                    Address = request.Request.Address,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status = true
                };

                var individualCustomer = new IndividualCustomer
                {
                    FirstName = request.Request.FirstName,
                    LastName = request.Request.LastName,
                    NationalId = request.Request.NationalId,
                    DateOfBirth = request.Request.DateOfBirth,
                    MotherName = request.Request.MotherName,
                    FatherName = request.Request.FatherName,
                    IsActive = true,
                    User = applicationUser
                };

                await _individualCustomerRepository.AddAsync(individualCustomer);

                var response = _mapper.Map<CreateIndividualCustomerResponse>(individualCustomer);
                response.Message = "Individual customer created successfully";
                return response;
            }
        }
    }
}