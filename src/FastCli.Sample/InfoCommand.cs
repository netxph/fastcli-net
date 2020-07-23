using FastCli.Sample.ViewInterfaces;
using FastCli.Sample.Controllers;
using System.CommandLine;
using System.CommandLine.Invocation;
using System;

namespace FastCli.Sample
{
    public class InfoCommand : ViewCommand, IInfoCommand
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
            : base("info", "Gets the information")
        {
            this.AddOption(
                new Option<string>("--title", "Sets the title"));

            Handler = CommandHandler.Create<string>(Run);

            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
            _controller.RegisterView(this);

            _cli = writer ?? throw new ArgumentNullException(nameof(writer));
        }

        public void Run(string title)
        {
            Title = title;

            _controller.Run();
        }
         
    }

}
