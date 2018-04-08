using System.Collections.Generic;
using System.Linq;

namespace FinancesApi.Strategy {
    public class AverageByMean : IAveragingMethod {
        public double AverageFor(List<int> values) {
            return values.Sum() / values.Count;
        }
    }
}