using AutoMapper;
using BankingCreditSystem.Application.Features.CorporateCustomers.DTOs.Requests;
using BankingCreditSystem.Application.Features.CorporateCustomers.DTOs.Responses;
using BankingCreditSystem.Domain.Entities;

namespace BankingCreditSystem.Application.Features.CorporateCustomers.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // Entity -> Response mappings
            CreateMap<CorporateCustomer, CorporateCustomerResponse>();
            CreateMap<CorporateCustomer, CreateCorporateCustomerResponse>();
            CreateMap<CorporateCustomer, UpdateCorporateCustomerResponse>();

            // Request -> Entity mappings
            CreateMap<CreateCorporateCustomerRequest, CorporateCustomer>();
            CreateMap<UpdateCorporateCustomerRequest, CorporateCustomer>();

            // Paginate mapping
            CreateMap<Paginate<CorporateCustomer>, Paginate<CorporateCustomerResponse>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
        }
    }
}