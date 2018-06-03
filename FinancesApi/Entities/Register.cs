using System;
using System.ComponentModel.DataAnnotations;

namespace FinancesApi.Entities {

    public class Register : IEntity {

        public Guid Id { get; set; }
        public Budget Budget { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}