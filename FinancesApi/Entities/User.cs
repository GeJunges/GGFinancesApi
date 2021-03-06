using System;

namespace FinancesApi.Entities {
    public class User : IEntity {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}