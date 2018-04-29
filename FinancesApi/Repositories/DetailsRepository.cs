using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinancesApi.Configirations;
using FinancesApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancesApi.Repositories {
    public class DetailsRepository : IDetailsRepository {
        private readonly AppDbContext _context;
        public DetailsRepository(AppDbContext context) {
            _context = context;
        }

        public async Task Add(ExpenseDetails expenseDetails) {
            if (expenseDetails.Detail.Id != null && expenseDetails.Detail.Id != Guid.Empty) {
                _context.Entry(expenseDetails.Detail).State = EntityState.Modified;
            }

            await _context.ExpensesDetails.AddAsync(expenseDetails);
            await _context.SaveChangesAsync();
        }

        public void Delete(ExpenseDetails entity) {
            _context.ExpensesDetails.Remove(entity);
            _context.SaveChanges();
        }


        public async Task<ICollection<ExpenseDetails>> FindDetailsByExpenseId(Guid ExpenseId) {
            return await _context.ExpensesDetails.ToListAsync();
        }

        public async Task<ExpenseDetails> FindExpenseDetails(Guid id) {
            return await _context.ExpensesDetails.FirstOrDefaultAsync(d => d.Id == id);
        }

        public void Update(Detail entity) {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}