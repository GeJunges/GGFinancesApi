using System;

namespace FinancesApi.Entities {
    public class User : IEntity {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}