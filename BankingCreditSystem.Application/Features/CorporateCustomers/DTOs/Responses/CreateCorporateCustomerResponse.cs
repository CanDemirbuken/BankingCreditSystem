namespace BankingCreditSystem.Application.Features.CorporateCustomers.DTOs.Responses
{
    public class CreateCorporateCustomerResponse
    {
        public Guid Id { get; set; }
        public string CustomerNumber { get; set; } = default!;
        public string CompanyName { get; set; } = default!;
        public string TaxNumber { get; set; } = default!;
        public DateTime CreatedDate { get; set; }
        public string Message { get; set; } = default!;
    }
} 