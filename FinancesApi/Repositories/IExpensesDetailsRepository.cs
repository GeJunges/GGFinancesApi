using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinancesApi.Entities;

namespace FinancesApi.Repositories {
    public interface IExpensesDetailsRepository {
        
        Task Add(ExpenseDetails expenseDetails);
        Task<ExpenseDetails> FindExpensesDetail(Guid id);
        Task<ICollection<ExpenseDetails>> FindDetailsByExpenseDateId(Guid id);
     }
}