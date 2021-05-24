using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FastCli.Hosting
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
            var args = new Dictionary<string, Argument>();

            foreach(var source in _internal)
            {
                foreach(var arg in source.Arguments)
                {
                    args[arg.Name] = arg;
                }
            }

            return string.Join(" ", args.Values.Select(v => v.ToString()));
        }

    }

}
