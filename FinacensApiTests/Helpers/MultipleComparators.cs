using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FinancesApiTests.Helpers {
    public class MultipleComparators : IComparator, IEnumerable<IComparator> {
        private readonly Dictionary<string, IComparator> _comparators = new Dictionary<string, IComparator>();

        public IComparator this[string key] {
            get {
                IComparator result;
                return _comparators.TryGetValue(key, out result) ? result : null;
            }
            set {
                if (value == null) {
                    _comparators.Remove(key);
                } else {
                    _comparators[key] = value;
                }
            }
        }

        public void Assert(object expected, object actual) {
            foreach (var property in _comparators.Values) {
                property.Assert(expected, actual);
            }
        }

        public bool AreEqual(object expected, object actual) => _comparators.Values.All(property => property.AreEqual(expected, actual));

        public IEnumerator<IComparator> GetEnumerator() => _comparators.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_comparators.Values).GetEnumerator();
    }
}