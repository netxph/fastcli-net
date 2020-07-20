namespace FastCli
{
    public class ArgumentConfiguration : IConfigurationSource
    {
        private string[] args;

        public ArgumentConfiguration(string[] args)
        {
            this.args = args;
        }
    }
}
