using application.lib.representations;

namespace application.lib.converters
{
    class BinaryToBoolArrayConverter : IConverter<BinaryRepresentation, bool[]>
    {
        public bool[] Convert(BinaryRepresentation value)
        {
            ushort valueSize = value.GetValueTypeSizeInBits();
            if (valueSize == 0)
            {
                throw new System.Exception("value type size must be greatr than 0");
            }
            bool[] boolArray = new bool[valueSize];
            ushort valueLength = value.Length;
            ushort currentDigitIndex = 0;
            ushort maxIndex = (ushort)(valueSize - 1);
            bool minimumIndexReached = false;
            foreach (ushort digit in value)
            {
                if (minimumIndexReached)
                {
                    throw new System.Exception("value length is greater than size of an array");
                }
                ushort offsetFromEnd = (ushort)(valueLength - currentDigitIndex++);

                if (offsetFromEnd != 0)
                {
                    ushort arrayIndex = (ushort)(maxIndex - offsetFromEnd);
                    minimumIndexReached = arrayIndex == 0;
                    boolArray[arrayIndex] = digit == 1;
                }
            }
            return boolArray;
        }
    }
}
