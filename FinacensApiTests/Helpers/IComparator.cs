namespace FinancesApiTests.Helpers {
    public interface IComparator {
        void Assert(object expected, object actual);
        bool AreEqual(object expected, object actual);
    }

    public interface IComparator<in TExpected, in TActual> : IComparator {
        void Assert(TExpected expected, TActual actual);
        bool AreEqual(TExpected expected, TActual actual);
    }
}