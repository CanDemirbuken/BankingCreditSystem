using BankingCreditSystem.Core.Security.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BankingCreditSystem.Core.Application.Pipelines.Authorization
{
    public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, ISecuredRequest
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthorizationBehavior(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();

            if (roleClaims == null) throw new UnauthorizedAccessException("Claims not found.");

            bool isNotMatchedARoleClaimWithRequestRoles =
                roleClaims.FirstOrDefault(roleClaim => request.Roles.Any(role => role == roleClaim)) == null;
            if (isNotMatchedARoleClaimWithRequestRoles) throw new UnauthorizedAccessException("You are not authorized.");

            TResponse response = await next();
            return response;
        }
    }
}