using Microsoft.VisualStudio.TestTools.UnitTesting;
using application.lib.comparers;
using application.lib.compareresults;

namespace ComparisonTests
{
    [TestClass]
    public class ComparisonTests
    {
        [TestMethod]
        public void IsGreater_SevenAndFour_ReturnsTrue()
        {
            PositiveIntegerComparer comparer = new PositiveIntegerComparer();

            CompareResultRegistry compareRegistry = comparer.Compare(7, 4);
            CompareResultsInterpretator resultInterptetator = new CompareResultsInterpretator(compareRegistry);

            Assert.IsTrue(resultInterptetator.IsGreater());
        }
        [TestMethod]
        public void IsSmaller_TwentyAndFive_ReturnsFalse()
        {
            PositiveIntegerComparer comparer = new PositiveIntegerComparer();

            CompareResultRegistry compareRegistry = comparer.Compare(20, 5);
            CompareResultsInterpretator resultInterptetator = new CompareResultsInterpretator(compareRegistry);

            Assert.IsFalse(resultInterptetator.IsSmaller());
        }
        [TestMethod]
        public void IsEqual_ThreeHundredAndThreeHundred_ReturnsTrue()
        {
            PositiveIntegerComparer comparer = new PositiveIntegerComparer();

            CompareResultRegistry compareRegistry = comparer.Compare(300, 300);
            CompareResultsInterpretator resultInterptetator = new CompareResultsInterpretator(compareRegistry);

            Assert.IsTrue(resultInterptetator.IsEqual());
        }
        [TestMethod]
        public void IsSmallerOrEqual_ZeroAndThirty_ReturnsTrue()
        {
            PositiveIntegerComparer comparer = new PositiveIntegerComparer();

            CompareResultRegistry compareRegistry = comparer.Compare(0, 30);
            CompareResultsInterpretator resultInterptetator = new CompareResultsInterpretator(compareRegistry);

            Assert.IsTrue(resultInterptetator.IsSmallerOrEqual());
        }
        [TestMethod]
        public void IsGreaterOrEqual_OneThousandAndTenThousand_ReturnsFalse()
        {
            PositiveIntegerComparer comparer = new PositiveIntegerComparer();

            CompareResultRegistry compareRegistry = comparer.Compare(1000, 10000);
            CompareResultsInterpretator resultInterptetator = new CompareResultsInterpretator(compareRegistry);

            Assert.IsFalse(resultInterptetator.IsGreaterOrEqual());
        }
    }
}
