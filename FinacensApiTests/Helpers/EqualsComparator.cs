using System.Collections;
using System.Linq;
using FinancesApi.Helpers;

namespace FinancesApiTests.Helpers {
    public delegate void ComparingHandler(string key, object expected, object actual, bool equals);

    public sealed class EqualsComparator : IComparator {
        public string Message { get; set; }

        public event ComparingHandler Comparing;

        public void Assert(object expected, object actual) => NUnit.Framework.Assert.AreEqual(expected, actual, Message);

        public bool AreEqual(object expected, object actual) {
            if (expected == null && actual == null) {
                OnComparing(Message, null, null, true);
                return true;
            }

            if (expected == null || actual == null) {
                OnComparing(Message, expected, actual, false);
                return false;
            }

            if (expected is string && actual is string) {
                var expectedString = (string)expected;
                var actualString = (string)actual;
                var stringEquals = Equals(expectedString, actualString);
                OnComparing(Message, expectedString, actualString, stringEquals);

                return stringEquals;
            }

            if (expected is IEnumerable && actual is IEnumerable) {
                return CompareEnumerable((IEnumerable)expected, (IEnumerable)actual);
            }

            var result = Equals(expected, actual);
            OnComparing(Message, expected, actual, result);
            return result;
        }

        private bool CompareEnumerable(IEnumerable expected, IEnumerable actual) {
            var enumerable1 = expected.Cast<object>().ToArray();
            var enumerable2 = actual.Cast<object>().ToArray();

            var sequenceEqual = enumerable1.SequenceEqual(enumerable2);
            OnComparing(Message, enumerable1.JoinToString(","), enumerable2.JoinToString(","), sequenceEqual);

            return sequenceEqual;
        }

        private void OnComparing(string key, object expected, object actual, bool equals)
            => Comparing?.Invoke(key, expected, actual, equals);
    }
}