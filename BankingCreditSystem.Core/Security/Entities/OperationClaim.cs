using BankingCreditSystem.Core.Repositories;

namespace BankingCreditSystem.Core.Security.Entities
{
    public class OperationClaim : Entity<int>
    {
        public string Name { get; set; } = default!;
    }
} 