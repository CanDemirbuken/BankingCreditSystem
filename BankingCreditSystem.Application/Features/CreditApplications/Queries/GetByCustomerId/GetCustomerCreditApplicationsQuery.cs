using AutoMapper;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Core.Application.Pipelines.Authorization;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BankingCreditSystem.Application.Features.CreditApplications.Queries.GetByCustomerId
{
    public class GetCustomerCreditApplicationsQuery : IRequest<List<CreditApplicationResponse>>, ISecuredRequest
    {
        public Guid CustomerId { get; set; }
        public string[] Roles => new[] { "Customer", "Admin", "BankStaff" };

        public class GetCustomerCreditApplicationsQueryHandler : IRequestHandler<GetCustomerCreditApplicationsQuery, List<CreditApplicationResponse>>
        {
            private readonly ICreditApplicationRepository _creditApplicationRepository;
            private readonly IMapper _mapper;

            public GetCustomerCreditApplicationsQueryHandler(ICreditApplicationRepository creditApplicationRepository, IMapper mapper)
            {
                _creditApplicationRepository = creditApplicationRepository;
                _mapper = mapper;
            }

            public async Task<List<CreditApplicationResponse>> Handle(GetCustomerCreditApplicationsQuery request, CancellationToken cancellationToken)
            {
                var creditApplications = await _creditApplicationRepository.GetListAsync(
                    predicate: x => x.CustomerId == request.CustomerId,
                    include: x => x.Include(c => c.CreditType).Include(c => c.Customer),
                    orderBy: x => x.OrderByDescending(c => c.CreatedDate),
                    cancellationToken: cancellationToken
                );

                var mappedCreditApplications = _mapper.Map<List<CreditApplicationResponse>>(creditApplications);
                return mappedCreditApplications;
            }
        }
    }
} 