using BankingCreditSystem.Core.Repositories;

namespace BankingCreditSystem.Core.Security.Entities
{
    public class UserOperationClaim : Entity<int>
    {
        public Guid UserId { get; set; }
        public Guid OperationClaimId { get; set; }
        public virtual User User { get; set; } = default!;
        public virtual OperationClaim OperationClaim { get; set; } = default!;
    }
} 