using System;

namespace FastCli.Hosting
{

    public class DefaultConsoleWriter : IConsoleWriter
    {

        public void Write(string output)
        {
            Console.Write(output);
        }

        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }
    }
}
