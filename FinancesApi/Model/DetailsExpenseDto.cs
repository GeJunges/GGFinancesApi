using System;

namespace FinancesApi.Model {
    public class DetailsExpenseDto {
        public string Id { get; set; }
        public string ExpenseDateId { get; set; }
        public DetailDto DetailDto { get; set; }
        public string Value { get; set; }
        public bool Paid { get; set; }
    }
}