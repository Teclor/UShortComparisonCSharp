using application.lib.representations;

namespace application.lib.converters
{
    class PositiveIntegerToBinaryConverter : IConverter<uint, BinaryRepresentation>
    {
        public BinaryRepresentation Convert(uint value)
        {
            ulong converted = 0;
            GetConverted(value, ref converted);
            return new BinaryRepresentation(converted);
        }

        private void GetConverted(uint value, ref ulong result)
        {
            if (value / 10 != 0)
            {
                GetConverted(value >> 1, ref result);
            }
            result = (result * 10) + (value & 1);
        }
    }
}
