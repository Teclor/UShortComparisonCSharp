using System;
using application.lib.comparers;
using application.lib.compareresults;

namespace application
{
    class Program
    {
        static void Main(string[] args)
        {
            PositiveIntegerComparer comparer = new PositiveIntegerComparer();
            CompareResultRegistry compareRegistry = comparer.Compare(7, 4);
            CompareResultsInterpretator resultInterptetator = new CompareResultsInterpretator(compareRegistry);

            Console.WriteLine(resultInterptetator.IsGreater());
        }
    }
}
