using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinancesApi.Entities;

namespace FinancesApi.Repositories {
    public interface ISearchRepository<T> where T : IEntity {
        Task<ICollection<T>> FindAll(Filter filter);
        Task<T> FindById(Guid id);
        Task<T> FindByEmail(string email);

        Task<ICollection<T>> FindByName(string name);
    }
}