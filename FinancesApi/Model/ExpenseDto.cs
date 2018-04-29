using FinancesApi.Entities;

namespace FinancesApi.Model {
    public class ExpenseDto {
        public string Id { get; set; }
        public Budget Budget { get; set; }
        public string Name { get; set; }
    }
}