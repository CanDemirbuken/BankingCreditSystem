namespace BankingCreditSystem.Application.Features.CorporateCustomers.DTOs.Responses
{
    public class UpdateCorporateCustomerResponse
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; } = default!;
        public string TaxNumber { get; set; } = default!;
        public DateTime UpdatedDate { get; set; }
        public string Message { get; set; } = default!;
    }
} 