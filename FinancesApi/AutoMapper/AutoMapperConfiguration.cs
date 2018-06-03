using AutoMapper;
using FinancesApi.Entities;
using FinancesApi.Model;

namespace FinancesApi.AutoMapper {
    public class AutoMapperConfiguration : Profile {

        public AutoMapperConfiguration() {

            CreateMap<Register, RegisterDto>().ReverseMap();

            CreateMap<IncomeDateDto, IncomeDate>()
                .ForMember(dest => dest.Register, memberOptions => memberOptions.MapFrom(source => source.RegisterDto));
            CreateMap<IncomeDate, IncomeDateDto>()
                .ForMember(dest => dest.RegisterDto, memberOptions => memberOptions.MapFrom(source => source.Register));

            CreateMap<ExpenseDateDto, ExpenseDate>()
                .ForMember(dest => dest.Register, memberOptions => memberOptions.MapFrom(source => source.RegisterDto))
                .ForMember(dest => dest.ExpenseDetails, memberOptions => memberOptions.MapFrom(source => source.ExpenseDetailsDto));
            CreateMap<ExpenseDate, ExpenseDateDto>()
                .ForMember(dest => dest.RegisterDto, memberOptions => memberOptions.MapFrom(source => source.Register))
                 .ForMember(dest => dest.ExpenseDetailsDto, memberOptions => memberOptions.MapFrom(source => source.ExpenseDetails));

            CreateMap<Detail, DetailDto>().ReverseMap();

            CreateMap<ExpenseDetails, ExpenseDetailsDto>()
                .ForMember(dest => dest.DetailDto, memberOptions => memberOptions.MapFrom(source => source.Detail));
            CreateMap<ExpenseDetailsDto, ExpenseDetails>()
                .ForMember(dest => dest.Detail, memberOptions => memberOptions.MapFrom(source => source.DetailDto));
        }
    }
}
