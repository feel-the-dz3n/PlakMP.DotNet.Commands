using System;
using System.Collections.Generic;
using System.Text;

namespace PlakMP.DotNet.Commands
{
    public class StringConverter : ITypeConverter
    {
        public Type InitialType => typeof(string);

        public Type ResultType => typeof(string);

        public object Convert(object from, string command)
        {
            throw new NotImplementedException();
        }
    }
}
