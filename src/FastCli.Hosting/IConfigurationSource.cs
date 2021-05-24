using System.Collections.Generic;

namespace FastCli.Hosting
{
    public interface IConfigurationSource
    {

        IEnumerable<Argument> Arguments { get; }

    }
}
