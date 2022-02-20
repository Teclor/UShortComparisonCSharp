using System;
using application.lib.compareresults;
using application.lib.converters;
using application.lib.representations;

namespace application.lib.comparers
{
    public class PositiveIntegerComparer : IComparer<ushort>
    {
        private readonly PositiveIntegerToBinaryConverter integerToBinaryConverter;
        private readonly BinaryToBoolArrayConverter binaryToBoolArrayConverter;
        public PositiveIntegerComparer()
        {
            integerToBinaryConverter = new PositiveIntegerToBinaryConverter();
            binaryToBoolArrayConverter = new BinaryToBoolArrayConverter();
        }
        public CompareResultRegistry Compare(ushort firstValue, ushort secondValue)
        {
            CompareResultRegistry compareRegistry = new CompareResultRegistry();
            LeftOperandIsGreaterResult leftIsGreaterResult = new LeftOperandIsGreaterResult();
            OperandsAreEqualResult operandsAreEqualResult = new OperandsAreEqualResult();
            RightOperandIsGreaterResult rightIsGreaterResult = new RightOperandIsGreaterResult();
            BinaryRepresentation leftOperand = integerToBinaryConverter.Convert(firstValue);
            BinaryRepresentation rightOperand = integerToBinaryConverter.Convert(secondValue);

            bool[] leftOperandBinaryAsBoolArray = binaryToBoolArrayConverter.Convert(leftOperand);
            bool[] rightOperandBinaryAsBoolArray = binaryToBoolArrayConverter.Convert(rightOperand);
            if (leftOperandBinaryAsBoolArray.Length != rightOperandBinaryAsBoolArray.Length)
            {
                throw new Exception("operands bool arrays must be the same length");
            }
            int maximumIndex = leftOperandBinaryAsBoolArray.Length - 1;
            ushort currentIndex = 0;
            while (currentIndex++ != maximumIndex)
            {
                if (leftOperandBinaryAsBoolArray[currentIndex] == rightOperandBinaryAsBoolArray[currentIndex])
                {
                    continue;
                }
                if (leftOperandBinaryAsBoolArray[currentIndex])
                {
                    leftIsGreaterResult.SetTrueState();
                    break;
                }
                if (rightOperandBinaryAsBoolArray[currentIndex])
                {
                    rightIsGreaterResult.SetTrueState();
                    break;
                }
            }
            if (!leftIsGreaterResult.GetState() && !rightIsGreaterResult.GetState())
            {
                operandsAreEqualResult.SetTrueState();
            }
            ICompareResult[] compareResultArray = new ICompareResult[3] { leftIsGreaterResult, operandsAreEqualResult, rightIsGreaterResult };
            compareRegistry.SetResultArray(compareResultArray);
            return compareRegistry;
        }
    }
}
