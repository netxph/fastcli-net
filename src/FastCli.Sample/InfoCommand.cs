using FastCli.Sample.ViewInterfaces;
using FastCli.Sample.Controllers;
using System.CommandLine;
using System.CommandLine.Invocation;
using System;

namespace FastCli.Sample
{
    public class InfoCommand : View, IInfoCommand
    {

        public string Title { get; set; }

        public string Message 
        {
            get 
            {
                throw new NotImplementedException();
            }
            set
            {
                _cli.WriteLine(value);
            }
        }

        private readonly InfoController _controller;
        private readonly IConsoleWriter _cli;

        public InfoCommand(InfoController controller, IConsoleWriter writer)
        {
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
            _controller.RegisterView(this);

            _cli = writer ?? throw new ArgumentNullException(nameof(writer));
        }

        protected override void Configure(ViewBuilder builder)
        {
            builder
                .Describe("info", "Gets the environment information")
                .WithOption(new Option<string>("--title"))
                .Execute(CommandHandler.Create<string>(Run));
        }

        public void Run(string title)
        {
            Title = title;

            _controller.Run();
        }
         
    }

}
