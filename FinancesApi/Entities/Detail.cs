using System;
using System.ComponentModel.DataAnnotations;

namespace FinancesApi.Entities {
    public class Detail : IEntity {
        public Guid Id { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}