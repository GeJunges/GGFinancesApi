using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinancesApi.Entities;

namespace FinancesApi.Repositories {
    public interface IIncomesDateRepository {
        Task Add(IncomeDate entryDate);
        Task<IncomeDate> FindById(Guid id);
        Task<ICollection<IncomeDate>> FindByDate( DateTime date);
    }
}