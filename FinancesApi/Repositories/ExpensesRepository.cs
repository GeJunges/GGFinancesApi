using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinancesApi.Configirations;
using FinancesApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancesApi.Repositories {
    public class ExpensesRepository : IExpensesRepository {
        private readonly AppDbContext _context;

        public ExpensesRepository(AppDbContext context) {
            _context = context;
        }

        public async Task Add(ExpenseDate expenseDate) {

            if (expenseDate.Expense.Id != null && expenseDate.Expense.Id != Guid.Empty) {
                _context.Entry(expenseDate.Expense).State = EntityState.Modified;
            }

            await _context.ExpensesDate.AddAsync(expenseDate);
            await _context.SaveChangesAsync();
        }

        public async Task<ExpenseDate> FindExpenseDate(Guid id) {
            return await _context.ExpensesDate.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<ICollection<ExpenseDate>> FindExpensesDate(Budget budget, DateTime date) {
            return await _context.ExpensesDate.ToListAsync();
        }

        public void Delete(ExpenseDate entity) {
            _context.ExpensesDate.Remove(entity);
            _context.SaveChanges();
        }
    }
}
