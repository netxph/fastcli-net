using System.Collections.Generic;
using System;
using System.Linq;

namespace FastCli.Hosting
{
    public class ArgumentConfiguration : IConfigurationSource
    {
        public IEnumerable<Argument> Arguments { get; }

        public ArgumentConfiguration(string[] args)
        {
            if(args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            var builder = new ArgumentBuilder(args);

            Arguments = builder.GetArguments();
        }
    }

    public class ArgumentBuilder
    {
        private readonly string[] _args;

        public ArgumentBuilder(string[] args)
        {
            _args = args ?? throw new ArgumentNullException(nameof(args));
        }

        public IEnumerable<Argument> GetArguments()
        {
            var arguments = new List<Argument>();

            var queue = new Queue<string>(_args);

            bool verbZone = true;
            while(queue.Any())
            {
                var arg = queue.Dequeue();

                if(arg.StartsWith("--") || arg.StartsWith("-"))
                {
                    var name = arg;
                    var values = new List<string>();

                    while(queue.Any() && !(queue.Peek().StartsWith("--") || queue.Peek().StartsWith("-")))
                    {
                        var token = queue.Dequeue();
                        values.Add(token);
                    }

                    var value = string.Join(" ", values);
                    if(value.Contains(" "))
                    {
                        value = $"\"{value}\"";
                    }

                    arguments.Add(new Argument(name, value));

                    verbZone = false;
                }

                if(verbZone)
                {
                    arguments.Add(new Argument(arg));
                }
            }

            return arguments;
        }
    }
}
