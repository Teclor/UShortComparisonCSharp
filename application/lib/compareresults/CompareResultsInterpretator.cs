namespace application.lib.compareresults
{
    public class CompareResultsInterpretator
    {
        private readonly CompareResultRegistry compareRegistry;
        public CompareResultsInterpretator(CompareResultRegistry compareRegistry)
        {
            this.compareRegistry = compareRegistry;
        }
        public bool IsGreater()
        {
            foreach (ICompareResult registryEntry in compareRegistry.GetTrueResults())
            {
                if (registryEntry.GetType() == typeof(LeftOperandIsGreaterResult))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsGreaterOrEqual()
        {
            foreach (ICompareResult registryEntry in compareRegistry.GetTrueResults())
            {
                if (registryEntry.GetType() == typeof(LeftOperandIsGreaterResult) || registryEntry.GetType() == typeof(OperandsAreEqualResult))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsEqual()
        {
            foreach (ICompareResult registryEntry in compareRegistry.GetTrueResults())
            {
                if (registryEntry.GetType() == typeof(OperandsAreEqualResult))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsSmallerOrEqual()
        {
            foreach (ICompareResult registryEntry in compareRegistry.GetTrueResults())
            {
                if (registryEntry.GetType() == typeof(RightOperandIsGreaterResult) || registryEntry.GetType() == typeof(OperandsAreEqualResult))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsSmaller()
        {
            foreach (ICompareResult registryEntry in compareRegistry.GetTrueResults())
            {
                if (registryEntry.GetType() == typeof(RightOperandIsGreaterResult))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
