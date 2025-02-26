namespace BankingCreditSystem.Application.Features.IndividualCustomers.DTOs.Requests
{
    public class CreateIndividualCustomerRequest
    {
        // IndividualCustomer Bilgileri
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string NationalId { get; set; } = default!;
        public DateTime DateOfBirth { get; set; }
        public string? MotherName { get; set; }
        public string? FatherName { get; set; }

        // ApplicationUser Bilgileri
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string Address { get; set; } = default!;
    }
}