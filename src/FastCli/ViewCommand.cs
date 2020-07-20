using Microsoft.Extensions.Logging;

namespace FastCli
{

    public class ViewCommand
    {
        private IConsole console;
        private ILogger logger;

        public ViewCommand(IConsole console, ILogger logger)
        {
            this.console = console;
            this.logger = logger;
        }
    }
}
