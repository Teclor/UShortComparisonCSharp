namespace application.lib.representations
{
    public interface IRepresentation<T>
    {
        public T GetValue();
        public bool CheckValueFitsType(T value);
    }
}
