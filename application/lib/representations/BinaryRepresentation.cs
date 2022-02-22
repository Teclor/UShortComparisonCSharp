using System.Collections;
using System.Collections.Generic;

namespace application.lib.representations
{
    public class BinaryRepresentation : BaseRepresentation<ulong>, IEnumerable<ushort>
    {
        public ushort Length => Count();
        private ushort? length = null;
        public BinaryRepresentation(ulong value) : base(value) { }
        public override bool CheckValueFitsType(ulong value)
        {
            return IsBinary(value);
        }
        public static bool IsBinary(ulong value)
        {
            bool[] digitsAvailability = new bool[10];
            ushort digit = 0;
            while ((digit / 10) == 0)
            {
                if (digit == 0 || digit == 1)
                {
                    digitsAvailability[digit] = true;
                }
                else
                {
                    digitsAvailability[digit] = false;
                }
                digit++;
            }
            while (value != 0)
            {
                if (!digitsAvailability[value % 10])
                {
                    return false;
                }
                value /= 10;
            }
            return true;
        }

        public ushort Count()
        {
            if (length == null)
            { 
                length = 0;
                IEnumerator enumerator = GetEnumerator();
                while (enumerator.MoveNext())
                {
                    length++;
                }
            }
            return length ?? 0;
        }
        public override ushort GetValueTypeSizeInBytes()
        {
            return sizeof(ushort);
        }
        public override ushort GetValueTypeSizeInBits()
        {
            return (ushort)(GetValueTypeSizeInBytes() * 8);
        }

        public IEnumerator<ushort> GetEnumerator()
        {
            ulong value = representation;
            while (value != 0)
            {
                yield return (ushort)(value % 10);
                value /= 10;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
