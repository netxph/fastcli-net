using System;
using System.CommandLine.Invocation;

namespace FastCli.Sample
{
    public class StatusCommand : View
    {
        protected override void Configure(ViewBuilder builder)
        {
            builder
                .Describe("status", "Gets the current status")
                .Execute(CommandHandler.Create(Run));
        }

        public void Run()
        {
            Console.WriteLine("This should display status");
        }
    }
}
