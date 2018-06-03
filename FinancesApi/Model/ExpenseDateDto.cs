using System;
using System.Collections.Generic;
using System.Linq;

namespace FinancesApi.Model {
    public class ExpenseDateDto {
        public string Id { get; set; }
        public RegisterDto RegisterDto { get; set; }
        public DateTime Date { get; set; }
        public List<ExpenseDetailsDto> ExpenseDetailsDto { get; set; }

        public virtual double? Total {
            get {
                if (ExpenseDetailsDto != null && ExpenseDetailsDto.Count > 0) {
                    return ExpenseDetailsDto.Sum(d => d?.Value);
                }
                return null;
            }
        }

        public ExpenseDateDto() {
            ExpenseDetailsDto = new List<ExpenseDetailsDto>();
        }
    }
}