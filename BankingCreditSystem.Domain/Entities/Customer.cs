using BankingCreditSystem.Core.Repositories;

namespace BankingCreditSystem.Domain.Entities
{
    public abstract class Customer : Entity<Guid>
    {
        public bool IsActive { get; set; } = true;

        public virtual ApplicationUser User { get; set; }
        public Guid UserId { get; set; }
    }
} 