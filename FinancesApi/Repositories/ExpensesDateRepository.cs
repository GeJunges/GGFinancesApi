using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancesApi.Configirations;
using FinancesApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancesApi.Repositories {
    public class ExpensesDateRepository : IExpensesDateRepository {
        private readonly AppDbContext _context;

        public ExpensesDateRepository(AppDbContext context) {
            _context = context;
        }

        public async Task Add(ExpenseDate expenseDate) {

            if (expenseDate.Register.Id != null && expenseDate.Register.Id != Guid.Empty) {
                _context.Entry(expenseDate.Register).State = EntityState.Modified;
            }

            await _context.ExpensesDate.AddAsync(expenseDate);
            await _context.SaveChangesAsync();
        }

        public async Task<ExpenseDate> FindById(Guid id) {
            return await _context.ExpensesDate.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<ICollection<ExpenseDate>> FindByDate(DateTime date) {
            return await _context.ExpensesDate.Where(e => e.Date == date)
                                                       .Include(e => e.Register)
                                                       .Include(list => list.ExpenseDetails)
                                                       .ToListAsync();
        }
    }
}
