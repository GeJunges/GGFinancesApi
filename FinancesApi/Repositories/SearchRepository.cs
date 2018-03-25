using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinancesApi.Entities;

namespace FinancesApi.Repositories {
    public class SearchRepository<T> : ISearchRepository<T> where T : IEntity {
        public Task<ICollection<T>> FindAll(Filter filter) {
            throw new NotImplementedException();

            
        }

        public Task<T> FindByEmail(string email) {
            throw new NotImplementedException();
        }

        public Task<T> FindById(Guid id) {
            throw new NotImplementedException();
        }

        public Task<ICollection<T>> FindByName(string name) {
            throw new NotImplementedException();
        }
    }
}