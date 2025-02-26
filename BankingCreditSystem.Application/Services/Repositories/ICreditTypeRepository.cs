using BankingCreditSystem.Domain.Entities;
using BankingCreditSystem.Domain.Enums;

namespace BankingCreditSystem.Application.Services.Repositories
{
    public interface ICreditTypeRepository : IAsyncRepository<CreditType, Guid>
    {
        Task<IList<CreditType>> GetByCustomerTypeAsync(CustomerType customerType);
        Task<IList<CreditType>> GetSubCreditTypesAsync(Guid parentCreditTypeId);
    }
} 