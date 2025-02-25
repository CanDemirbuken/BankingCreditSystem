namespace BankingCreditSystem.Application.Features.CorporateCustomers.DTOs.Requests
{
    public class UpdateCorporateCustomerRequest
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; } = default!;
        public string TaxNumber { get; set; } = default!;
        public string TaxOffice { get; set; } = default!;
        public string CompanyRegistrationNumber { get; set; } = default!;
        public string AuthorizedPerson { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Address { get; set; } = default!;
    }
} 