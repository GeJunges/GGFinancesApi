using System.Threading.Tasks;
using FinancesApi.Entities;

namespace FinancesApi.Repositories {
    public class PersistenceRepository<T> : IPersistenceRepository<T> where T : IEntity {
        public Task Delete(T entity) {
            throw new System.NotImplementedException();
        }

        public Task Insert(T entity) {
            throw new System.NotImplementedException();
        }

        public Task Update(T entity) {
            throw new System.NotImplementedException();
        }
    }
}