using AutoMapper;
using BankingCreditSystem.Application.Features.IndividualCustomers.Commands.Create;
using BankingCreditSystem.Application.Features.IndividualCustomers.DTOs.Requests;
using BankingCreditSystem.Domain.Entities;

namespace BankingCreditSystem.Application.Features.IndividualCustomers.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<IndividualCustomer, IndividualCustomerResponse>().ReverseMap();
            CreateMap<IndividualCustomer, CreateIndividualCustomerResponse>().ReverseMap();
            CreateMap<IndividualCustomer, UpdatedIndividualCustomerResponse>().ReverseMap();

            CreateMap<UpdateIndividualCustomerRequest, IndividualCustomer>().ReverseMap();
            
            // CreateIndividualCustomerRequest to IndividualCustomer mapping
            CreateMap<CreateIndividualCustomerRequest, IndividualCustomer>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => new ApplicationUser
                {
                    Email = src.Email,
                    PhoneNumber = src.PhoneNumber,
                    Address = src.Address,
                    Status = true
                }));

            // CreateIndividualCustomerCommand to IndividualCustomer mapping
            CreateMap<CreateIndividualCustomerCommand, IndividualCustomer>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Request.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Request.LastName))
                .ForMember(dest => dest.NationalId, opt => opt.MapFrom(src => src.Request.NationalId))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.Request.DateOfBirth))
                .ForMember(dest => dest.MotherName, opt => opt.MapFrom(src => src.Request.MotherName))
                .ForMember(dest => dest.FatherName, opt => opt.MapFrom(src => src.Request.FatherName))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => new ApplicationUser
                {
                    Email = src.Request.Email,
                    PhoneNumber = src.Request.PhoneNumber,
                    Address = src.Request.Address,
                    Status = true
                }));

            CreateMap<Paginate<IndividualCustomer>, Paginate<IndividualCustomerResponse>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
        }
    }
}