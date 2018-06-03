using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinancesApi.Entities;

namespace FinancesApi.Repositories {
    public interface IExpensesDateRepository {
        Task Add(ExpenseDate expenseDate);
        Task<ExpenseDate> FindById(Guid id);
        Task<ICollection<ExpenseDate>> FindByDate(DateTime date);
    }
}