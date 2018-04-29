using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinancesApi.Entities;

namespace FinancesApi.Repositories {
    public interface IDetailsRepository {
        
        Task Add(ExpenseDetails expenseDetails);
        Task<ExpenseDetails> FindExpenseDetails(Guid id);
        void Delete(ExpenseDetails entity);
        Task<ICollection<ExpenseDetails>> FindDetailsByExpenseId(Guid id);
    }
}