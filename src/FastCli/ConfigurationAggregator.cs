using System.Collections;
using System.Collections.Generic;

namespace FastCli
{

    public class ConfigurationAggregator : IEnumerable<IConfigurationSource>
    {
        private readonly List<IConfigurationSource> _internal;

        public ConfigurationAggregator()
        {
            _internal = new List<IConfigurationSource>();
        }

        public void Add(IConfigurationSource source)
        {
            if(source != null)
            {
                _internal.Add(source);
            }
        }

        public IEnumerator<IConfigurationSource> GetEnumerator()
        {
            return _internal.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public string ToArgs()
        {
            return "--help";
        }

    }

}
