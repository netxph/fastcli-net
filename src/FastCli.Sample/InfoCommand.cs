using FastCli.Sample.ViewInterfaces;
using FastCli.Sample.Controllers;
using System.CommandLine;
using System.CommandLine.Invocation;
using System;

namespace FastCli.Sample
{
    public class InfoCommand : Command, IInfoCommand
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
                Console.WriteLine(value);
            }
        }

        private readonly InfoController _controller;

        public InfoCommand(InfoController controller)
            : base("info", "Gets the information")
        {
            this.AddOption(
                new Option<string>("--title", "Sets the title"));

            Handler = CommandHandler.Create<string>(Run);

            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
            _controller.RegisterView(this);
        }

        public void Run(string title)
        {
            Title = title;

            _controller.Run();
        }
         
    }

}
