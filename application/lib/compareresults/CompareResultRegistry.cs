using System.Collections;
using System.Collections.Generic;


namespace application.lib.compareresults
{
    public class CompareResultRegistry : IEnumerable<ICompareResult>
    {
        protected HashSet<ICompareResult> results;
        public void Clear() => results.Clear();
        public CompareResultRegistry()
        {
            results = new HashSet<ICompareResult>();
        }
        public void AddResult(ICompareResult result)
        {
            results.Add(result);
        }
        public void AddResultArray(ICompareResult[] resultArray)
        {
            results.UnionWith(resultArray);
        }
        public void SetResultArray(ICompareResult[] resultArray)
        {
            Clear();
            results.UnionWith(resultArray);
        }
        public List<ICompareResult> GetTrueResults()
        {
            List<ICompareResult> trueResults = new List<ICompareResult>();
            foreach (ICompareResult result in this)
            {
                if (result.GetState())
                {
                    trueResults.Add(result);
                }
            }
            return trueResults;
        }

        public IEnumerator<ICompareResult> GetEnumerator()
        {
            return results.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
