using System;

namespace FinancesApi.AutoMapper {
    public interface ICustomMappingInitializer { 
         Type[] GetTypesFromAssembly();
    }
}