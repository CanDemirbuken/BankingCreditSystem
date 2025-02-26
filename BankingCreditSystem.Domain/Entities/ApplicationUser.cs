using BankingCreditSystem.Core.Security.Entities;

namespace BankingCreditSystem.Domain.Entities
{
    public class ApplicationUser : User
    {
        public string PhoneNumber { get; set; } = default!;
        public string Address { get; set; } = default!;

        public virtual Customer? Customer { get; set; } = default!;
        public Guid CustomerId { get; set; }
    }
}