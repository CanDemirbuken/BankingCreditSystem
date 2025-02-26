using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Core.Security.Hashing;
using BankingCreditSystem.Persistence.Contexts;
using BankingCreditSystem.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankingCreditSystem.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IIndividualCustomerRepository, IndividualCustomerRepository>();
            services.AddScoped<ICorporateCustomerRepository, CorporateCustomerRepository>();
            services.AddScoped<ICreditTypeRepository, CreditTypeRepository>();
            services.AddScoped<ICreditApplicationRepository, CreditApplicationRepository>();
            services.AddScoped<IHashingHelper, HashingHelper>();
            //services.AddScoped<IUserRepository, UserRepository>();
            // Diğer repository'ler buraya eklenecek

            return services;
        }
    }
}