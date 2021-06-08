# fastcli-net
CLI application still matters nowadays. They are the fastest way to implement proof of concepts or as simple as giving API an interface.

`FastCli` gives users an elegant way of creating CLI applications in `dotnet`. It wraps Microsoft's `commandline-api` and provides you the following features out-of-the-box.

* Testable
* Dependency Injection
* Argument Hierarchies

### Installation

> dotnet add package fastcli

### Quick Start

Let's first create a `greet` command.

```csharp
public class PersonCommand : View
{
    protected override void Configure(ViewBuilder builder)
    {
        builder
            .Describe("person", "Greets by person")
            .WithOption(new Option<string>("--name", "Name of the person"))
            .Execute(CommandHandler.Create<string>(Run))
    }
    
    public void Run(string name)
    {
        Console.WriteLine($"Hello {name}!!!");
    }
}
```

This shows you how clean and simple the implementation. Now let's define our `CliHost` application.

```csharp
public class MainHost : CliHost
{
    protected override void ConfigureCommands(CommandBuilder builder)
    {
    	builder
            .AddVerb("greet", "Provides operations for greeting")
            	.RegisterCommand<PersonCommand>();
        	.AddVerb("info", "Provides information about the app")
                .RegisterCommand<EnvCommand>();
    }
    
    protected override void ConfigureServices(IServiceCollection services)
    {
        services
            .AddTransient<PersonCommand>()
            .AddTransient<EnvCommand>();
    }
}
```

Notice that the `CliHost` has built-in dependency injection container. With this, you can easily turn this simple CLI into a full Model-View-Presenter implementation in no time.

Lastly, here's how you are going to use it with the `main` method.

```csharp
class Program
{
    static void Main(string[] args)
    {
        new MainHost()
            .Describe("Greeter Program (c) 2020 All Rights Reserved.")
            .Use(new ArgumentConfiguration(args))
            .Start();
    }
}
```

Notice the argument hierarchy management using the method `Use`. Even if the argument is missing it will try to aggregate them using various sources.

We are done, compile it to create `hello.exe` and run this application using `hello greet person --name "John Doe"`. Help is already integrated so you could also get them using `hello --help`.

#### Model-View-Presenter Passive View

I've created a sample in the project that implements MVP-Passive View and created using TDD.

### Contributing

Feel free to send me pull requests. This is just an MVP for now. I still have plans to fully wrap the `commandline api` and the `dependency injection` providers, so that the consumer can freely use any library they please.

### License

MIT License
