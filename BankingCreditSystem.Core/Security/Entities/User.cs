using BankingCreditSystem.Core.Repositories;

namespace BankingCreditSystem.Core.Security.Entities
{
    public class User : Entity<Guid>
    {
        public string Email { get; set; } = default!;
        public byte[] PasswordSalt { get; set; } = default!;
        public byte[] PasswordHash { get; set; } = default!;
        public bool Status { get; set; }

        public User()
        {
            Status = true;
        }
    }
} 