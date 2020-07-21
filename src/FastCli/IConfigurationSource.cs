using System.Collections.Generic;

namespace FastCli
{
    public interface IConfigurationSource
    {

        IEnumerable<Argument> Arguments { get; }

    }
}
