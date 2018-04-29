using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinancesApi.Entities;

namespace FinancesApi.Repositories {
    public interface IExpensesRepository {
        Task Add(ExpenseDate expenseDate);
        Task<ExpenseDate> FindExpenseDate(Guid id);
        void Delete(ExpenseDate entity);
        Task<ICollection<ExpenseDate>> FindExpensesDate(Budget budget, DateTime date);
    }
}