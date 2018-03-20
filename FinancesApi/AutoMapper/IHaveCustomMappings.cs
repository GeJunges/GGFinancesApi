using AutoMapper;

namespace FinancesApi.AutoMapper {
    public interface IHaveCustomMappings {
        void CreateMappings(IProfileExpression profile);
    }
}