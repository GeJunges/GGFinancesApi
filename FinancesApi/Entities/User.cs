using System;

namespace FinancesApi.Entities {
    public class User : IEntity {
        public int Id { get; set; }
        public Guid Identifier { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Email { get; set; }
    }
}