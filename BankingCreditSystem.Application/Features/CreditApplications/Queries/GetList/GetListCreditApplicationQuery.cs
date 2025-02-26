using AutoMapper;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Core.Application.Pipelines.Authorization;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BankingCreditSystem.Application.Features.CreditApplications.Queries.GetList
{
    public class GetListCreditApplicationQuery : IRequest<List<CreditApplicationResponse>>, ISecuredRequest
    {
        public string[] Roles => new[] { "Admin", "BankStaff" };

        public class GetListCreditApplicationQueryHandler : IRequestHandler<GetListCreditApplicationQuery, List<CreditApplicationResponse>>
        {
            private readonly ICreditApplicationRepository _creditApplicationRepository;
            private readonly IMapper _mapper;

            public GetListCreditApplicationQueryHandler(ICreditApplicationRepository creditApplicationRepository, IMapper mapper)
            {
                _creditApplicationRepository = creditApplicationRepository;
                _mapper = mapper;
            }

            public async Task<List<CreditApplicationResponse>> Handle(GetListCreditApplicationQuery request, CancellationToken cancellationToken)
            {
                var creditApplications = await _creditApplicationRepository.GetListAsync(
                    include: x => x.Include(c => c.CreditType).Include(c => c.Customer),
                    cancellationToken: cancellationToken
                );

                var mappedCreditApplications = _mapper.Map<List<CreditApplicationResponse>>(creditApplications);
                return mappedCreditApplications;
            }
        }
    }
} 