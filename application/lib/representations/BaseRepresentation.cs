using System;

namespace application.lib.representations
{
    public abstract class BaseRepresentation<T> : IRepresentation<T>
    {
        protected T representation;
        public BaseRepresentation(T value)
        {
            if (!CheckValueFitsType(value))
            {
                throw new ArgumentException();
            }
            representation = value;
        }

        public abstract bool CheckValueFitsType(T Value);
        public T GetValue()
        {
            return representation;
        }
        abstract public ushort GetValueTypeSizeInBytes();
        abstract public ushort GetValueTypeSizeInBits();
    }
}
