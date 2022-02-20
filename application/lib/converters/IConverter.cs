using System;
using System.Collections.Generic;
using System.Text;

namespace application.lib.converters
{
    public interface IConverter<InputType, OutputType>
    {
        public OutputType Convert(InputType value);
    }
}
