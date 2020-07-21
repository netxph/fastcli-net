using System;

namespace FastCli
{

    public class Argument
    {
        public Argument(string name, string value)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;

            Value = value ?? string.Empty;
        }

        public Argument(string name)
            :this(name, string.Empty)
        {
        }

        public string Name { get; }

        public string Value { get; }

        public override string ToString()
        {
            return $"{Name} {Value}".Trim();
        }
    }
}
