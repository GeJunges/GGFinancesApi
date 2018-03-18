using System;
using System.Collections.Generic;
using System.Linq;

namespace FinancesApi.Helpers {
 public static class EnumerableExtensions {
        public static IEnumerable<T[]> SplitInBatches<T>(this IEnumerable<T> self, int itemsPorBatch, bool balanced = true) {
            if (itemsPorBatch <= 0) {
                throw new ArgumentOutOfRangeException(nameof(itemsPorBatch));
            }

            var elementos = self.ToArray();
            if (elementos.Length == 0) {
                yield break;
            }

            var total = (decimal) elementos.Length;
            var numeroDeBatches = (int) Math.Ceiling(total / itemsPorBatch);
            if (balanced) {
                itemsPorBatch = (int) Math.Ceiling(total / numeroDeBatches);
            }
            for (var numeroDoBatch = 0; numeroDoBatch < numeroDeBatches; numeroDoBatch++) {
                yield return elementos.Skip(numeroDoBatch * itemsPorBatch).Take(itemsPorBatch).ToArray();
            }
        }

        public static string JoinToString<TValue>(this IEnumerable<TValue> source, string separator, Func<TValue, string> mapper = null) {
            if (source == null) {
                throw new ArgumentNullException(nameof(source));
            }
            if (separator == null) {
                throw new ArgumentNullException(nameof(separator));
            }

            return mapper == null
                ? string.Join(separator, source)
                : string.Join(separator, source.Select(mapper));
        }
    }
}