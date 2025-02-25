namespace BankingCreditSystem.Application.Features.CorporateCustomers.DTOs.Responses
{
    public class DeletedCorporateCustomerResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; } = default!;
    }
} 