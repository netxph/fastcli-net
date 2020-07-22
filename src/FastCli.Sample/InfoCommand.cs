using FastCli.Sample.ViewInterfaces;
using FastCli.Sample.Controllers;
using System.CommandLine;
using System.CommandLine.Invocation;
using System;

namespace FastCli.Sample
{
    public class InfoCommand : Command, IInfoCommand
    {
        public string IsDetailed { get; set; }

        public InfoCommand(InfoController controller)
            : base("info", "Gets the information")
        {
            this.AddOption(
                new Option("--verbose", "Show detailed information"));

            Handler = CommandHandler.Create<bool>(Run);

        }

        public virtual void Run(bool verbose)
        {
            Console.WriteLine($"Hello the value of verbose is {verbose}.");
        }
         
    }

}
