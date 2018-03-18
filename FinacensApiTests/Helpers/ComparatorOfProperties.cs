using System.Reflection;

namespace FinancesApiTests.Helpers {
    public class ComparatorOfProperties : IComparator {
        public ComparatorOfProperties(PropertyInfo expectedProperty, PropertyInfo actualProperty) {
            ExpectedProperty = expectedProperty;
            ActualProperty = actualProperty;

            var equalsComparator = new EqualsComparator
            {
                Message = expectedProperty.Name
            };
            equalsComparator.Comparing += OnComparing;

            Comparator = equalsComparator;
        }

        public ComparatorOfProperties(PropertyInfo expectedProperty, PropertyInfo actualProperty, IComparator comparator) {
            Comparator = comparator;
            ExpectedProperty = expectedProperty;
            ActualProperty = actualProperty;
        }

        public string Key => ExpectedProperty.Name;

        public PropertyInfo ExpectedProperty { get; }

        public PropertyInfo ActualProperty { get; }

        public IComparator Comparator { get; set; }

        public event ComparingHandler Comparing;

        public void Assert(object expected, object actual) => Comparator.Assert(ExpectedProperty.GetValue(expected), ActualProperty.GetValue(actual));

        public bool AreEqual(object expected, object actual) => Comparator.AreEqual(ExpectedProperty.GetValue(expected), ActualProperty.GetValue(actual));

        protected virtual void OnComparing(string key, object expected, object actual, bool equals)
            => Comparing?.Invoke(key, expected, actual, equals);
    }
}