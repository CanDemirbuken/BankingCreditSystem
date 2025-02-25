using BankingCreditSystem.Application.Features.CorporateCustomers.Constants;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Core.CrossCuttingConcerns.Exceptions.Types;

namespace BankingCreditSystem.Application.Features.CorporateCustomers.Rules
{
    public class CorporateCustomerBusinessRules
    {
        private readonly ICorporateCustomerRepository _corporateCustomerRepository;

        public CorporateCustomerBusinessRules(ICorporateCustomerRepository corporateCustomerRepository)
        {
            _corporateCustomerRepository = corporateCustomerRepository;
        }

        public async Task CustomerShouldExistWhenRequested(Guid id)
        {
            var customer = await _corporateCustomerRepository.GetAsync(c => c.Id == id);
            if (customer is null)
                throw new BusinessException(CorporateCustomerMessages.CustomerNotFound);
        }

        public async Task TaxNumberCannotBeDuplicatedWhenInserted(string taxNumber)
        {
            var result = await _corporateCustomerRepository.AnyAsync(c => c.TaxNumber == taxNumber);
            if (result)
                throw new BusinessException(CorporateCustomerMessages.TaxNumberExists);
        }

        public Task TaxNumberValidation(string taxNumber)
        {
            if (string.IsNullOrEmpty(taxNumber) || taxNumber.Length != 10 || !taxNumber.All(char.IsDigit))
                throw new BusinessException("Tax number must be 10 digits.");

            return Task.CompletedTask;
        }

        public Task EmailValidation(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
                throw new BusinessException("Invalid email format.");

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                if (addr.Address != trimmedEmail)
                    throw new BusinessException("Invalid email format.");
            }
            catch
            {
                throw new BusinessException("Invalid email format.");
            }

            return Task.CompletedTask;
        }

        //public Task PhoneNumberValidation(string phoneNumber)
        //{
        //    if (string.IsNullOrEmpty(phoneNumber) || phoneNumber.Length < 10 || !phoneNumber.All(c => char.IsDigit(c) || c == '+'))
        //        throw new BusinessException("Invalid phone number format.");

        //    return Task.CompletedTask;
        //}
    }
} 