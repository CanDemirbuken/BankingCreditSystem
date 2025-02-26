namespace BankingCreditSystem.Application.Features.CreditTypes.Constants
{
    public static class CreditTypeMessages
    {
        public const string CreditTypeNotFound = "Credit type not found.";
        public const string CreditTypeNameExists = "A credit type with this name already exists.";
        public const string CreditTypeCreated = "Credit type created successfully.";
        public const string CreditTypeUpdated = "Credit type updated successfully.";
        public const string CreditTypeDeleted = "Credit type deleted successfully.";
        public const string InvalidAmountRange = "Maximum amount must be greater than minimum amount.";
        public const string InvalidTermRange = "Maximum term must be greater than minimum term.";
    }
} 