using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FinancesApi.Entities {
    public class ExpenseDate : IEntity {

        public Guid Id { get; set; }
        [Required]
        public virtual Register Register { get; set; }
        public DateTime Date { get; set; }
        public List<ExpenseDetails> ExpenseDetails { get; set; }
    }
}