using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancesApi.Configirations;
using FinancesApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancesApi.Repositories {
    public class RegisterRepository : IRegisterRepository {

        private readonly AppDbContext _context;

        public RegisterRepository(AppDbContext context) {
            _context = context;
        }

        public async Task<ICollection<Register>> Find(Budget budget) {
            return await _context.Registers.Where(e => e.Budget == budget).ToListAsync();
        }
    }
}
