using application.lib.compareresults;

namespace application.lib.comparers
{
    public interface IComparer<T>
    {
        public CompareResultRegistry Compare(T firstValue, T secondValue);
    }
}
