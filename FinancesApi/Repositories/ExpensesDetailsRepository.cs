using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancesApi.Configirations;
using FinancesApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancesApi.Repositories {
    public class ExpensesDetailsRepository : IExpensesDetailsRepository {
        private readonly AppDbContext _context;
        public ExpensesDetailsRepository(AppDbContext context) {
            _context = context;
        }

        public async Task Add(ExpenseDetails expenseDetails) {
            if (expenseDetails.Detail.Id != null && expenseDetails.Detail.Id != Guid.Empty) {
                _context.Entry(expenseDetails.Detail).State = EntityState.Modified;
            }

            await _context.ExpensesDetails.AddAsync(expenseDetails);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<ExpenseDetails>> FindDetailsByExpenseDateId(Guid expenseDateId) {
            return await _context.ExpensesDetails
                                 .Where(e => e.ExpenseDateId == expenseDateId)
                                 .Include(d => d.Detail).ToListAsync();
        }

        public async Task<ExpenseDetails> FindExpensesDetail(Guid id) {
            return await _context.ExpensesDetails
                                 .Include(d => d.Detail)
                                .FirstOrDefaultAsync(d => d.Id == id);
        }
    }
}