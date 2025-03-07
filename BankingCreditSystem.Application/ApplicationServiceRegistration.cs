using BankingCreditSystem.Application.Features.CorporateCustomers.Rules;
using BankingCreditSystem.Application.Features.IndividualCustomers.Rules;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using BankingCreditSystem.Core.Application.Pipelines.Authorization;
using MediatR;

namespace BankingCreditSystem.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(configuration => 
            {
                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                configuration.AddBehavior(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            });
            
            services.AddScoped<IndividualCustomerBusinessRules>();
            services.AddScoped<CorporateCustomerBusinessRules>();
            // Diğer business rules sınıfları buraya eklenecek

            return services;
        }
    }
} 