namespace FastCli.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            new MainHost()
                .Describe("This is a sample scaffold of FastCli")
                .Use(new ArgumentConfiguration(args))
                .Start();
        }
    }

}
