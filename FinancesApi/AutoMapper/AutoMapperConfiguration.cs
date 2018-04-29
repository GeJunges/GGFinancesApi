using AutoMapper;
using FinancesApi.Entities;
using FinancesApi.Model;

namespace FinancesApi.AutoMapper {
    public class AutoMapperConfiguration : Profile {

        public AutoMapperConfiguration() {
            CreateMap<Expense, ExpenseDto>().ReverseMap();

            CreateMap<ExpenseDateDto, ExpenseDate>()
                .ForMember(dest => dest.Expense, memberOptions =>
                           memberOptions.MapFrom(source => source.ExpenseDto));
            CreateMap<ExpenseDate, ExpenseDateDto>()
                .ForMember(dest => dest.ExpenseDto, memberOptions =>
                           memberOptions.MapFrom(source => source.Expense));

            CreateMap<Detail, DetailDto>().ReverseMap();
            CreateMap<ExpenseDetails, DetailsExpenseDto>()
                .ForMember(dest => dest.DetailDto, memberOptions =>
                           memberOptions.MapFrom(source => source.Detail));
            CreateMap<DetailsExpenseDto, ExpenseDetails>()
                .ForMember(dest => dest.Detail, memberOptions =>
                           memberOptions.MapFrom(source => source.DetailDto));
        }
    }
}
