using System;

namespace PlakMP.DotNet.Commands
{
    public interface ITypeConverter
    {
        Type InitialType { get; }
        Type ResultType { get; }

        object Convert(object from, string command);
    }
}
