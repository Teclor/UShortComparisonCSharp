namespace application.lib.converters
{
    public interface IConverter<InputType, OutputType>
    {
        public OutputType Convert(InputType value);
    }
}
