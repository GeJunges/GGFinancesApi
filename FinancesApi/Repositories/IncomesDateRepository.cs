using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancesApi.Configirations;
using FinancesApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancesApi.Repositories {
    public class IncomesDateRepository : IIncomesDateRepository {
        private readonly AppDbContext _context;

        public IncomesDateRepository(AppDbContext context) {
            _context = context;
        }

        public async Task Add(IncomeDate incomeDate) {

            if (incomeDate.Register.Id != null && incomeDate.Register.Id != Guid.Empty) {
                _context.Entry(incomeDate.Register).State = EntityState.Modified;
            }
            
            await _context.EntriesDate.AddAsync(incomeDate);
            await _context.SaveChangesAsync();
        }

        public async Task<IncomeDate> FindById(Guid id) {
            return await _context.EntriesDate.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<ICollection<IncomeDate>> FindByDate(DateTime date) {
            return await _context.EntriesDate.Where(e => e.Date == date)
                                                       .Include(e => e.Register)
                                                       .ToListAsync();
        }
    }
}
