using System.Collections.Generic;
using System.Linq;

namespace FinancesApi.Model {
    public class IncomesList {
        
        public List<IncomeDateDto> Details { get; set; }

        public virtual double? Total {
            get {
                if (Details.Count > 0) {
                    return Details.Sum(d => d?.Value);
                }
                return null;
            }
        }

        public IncomesList() {
            Details = new List<IncomeDateDto>();
        }
    }
}