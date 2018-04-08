using System;
using System.Collections.Generic;
using System.Linq;

namespace FinancesApi.Strategy {
    public class CalculatorFactory {
        public IAveragingMethod Create(TypeOfCalc type) {
            switch (type) {
                case TypeOfCalc.AverangeByMean:
                    return new AverageByMean();
                case TypeOfCalc.AverangeByMedian:
                    return new AverageByMedian();
                default:
                    throw new ArgumentNullException("Strategy doesn't found!");
            }
        }
    }
}
