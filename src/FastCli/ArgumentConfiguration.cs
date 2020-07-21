using System.Collections.Generic;

namespace FastCli
{
    public class ArgumentConfiguration : IConfigurationSource
    {
        private string[] args;

        public IEnumerable<Argument> Arguments { get; }

        public ArgumentConfiguration(string[] args)
        {
            this.args = args;
        }
    }
}
