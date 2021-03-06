﻿using System.Collections.Generic;
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

        public async Task<ICollection<Detail>> Find() {
            return await _context.Details.ToListAsync();
        }
    }
}
