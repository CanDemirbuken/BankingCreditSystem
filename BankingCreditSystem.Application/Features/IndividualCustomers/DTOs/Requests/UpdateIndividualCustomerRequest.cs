namespace BankingCreditSystem.Application.Features.IndividualCustomers.DTOs.Requests
{
    public class UpdateIndividualCustomerRequest
    {
        // Customer Bilgileri
        public Guid Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string? MotherName { get; set; }
        public string? FatherName { get; set; }

        // ApplicationUser Bilgileri
        public string PhoneNumber { get; set; } = default!;
        public string Address { get; set; } = default!;
    }
}