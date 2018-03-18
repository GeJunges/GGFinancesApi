using System;
using System.Collections;
using System.Linq;

namespace FinancesApiTests.Helpers {
    public class ComparatorOfObjects<TExpected, TActual> : MultipleComparators, IComparator<TExpected, TActual>, IComparer {
        public ComparatorOfObjects<TExpected, TActual> AddMatches() {
            var comparators =
                from expectedProperty in typeof(TExpected).GetProperties().Where(property => property.CanRead)
                join actualProperty in typeof(TActual).GetProperties().Where(property => property.CanRead)
                on new {
                    expectedProperty.Name,
                    expectedProperty.PropertyType
                } equals new {
                    actualProperty.Name,
                    actualProperty.PropertyType
                }
                select new ComparatorOfProperties(expectedProperty, actualProperty);

            foreach (var comparator in comparators) {
                comparator.Comparing += OnComparing;
                base[comparator.Key] = comparator;
            }

            return this;
        }

        public event ComparingHandler Comparing;

        public ComparatorOfObjects<TExpected, TActual> AddProperty(params string[] keys) {
            foreach (var key in keys) {
                base[key] = new ComparatorOfProperties(typeof(TExpected).GetProperty(key), typeof(TActual).GetProperty(key));
            }

            return this;
        } 

        public void Assert(TExpected expected, TActual actual) => base.Assert(expected, actual);

        public bool AreEqual(TExpected expected, TActual actual) => base.AreEqual(expected, actual);

        public int Compare(object x, object y) => AreEqual(x, y) ? 0 : -1;

        public ComparatorOfObjects<TExpected, TActual> LogUnequalsOnConsole() {
            Comparing += (key, expected, actual, equals) => {
                if (equals == false) {
                    Console.WriteLine($@"  Values differ at {key}:
  Expected: {expected}
  But was: {actual}");
                }
            };

            return this;
        }

        protected virtual void OnComparing(string key, object expected, object value, bool equals) {
            Comparing?.Invoke(key, expected, value, equals);
        }
    }

    public static class ComparatorOfObjects {
        public static ComparatorOfObjects<TClass, TClass> Create<TClass>() => new ComparatorOfObjects<TClass, TClass>().AddMatches();

        public static ComparatorOfObjects<TClass1, TClass2> Create<TClass1, TClass2>() => new ComparatorOfObjects<TClass1, TClass2>().AddMatches();
    }
}