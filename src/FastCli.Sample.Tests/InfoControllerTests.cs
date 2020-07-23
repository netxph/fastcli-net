using System;
using Xunit;
using Moq;
using FluentAssertions;
using FastCli.Sample.ViewInterfaces;
using FastCli.Sample.Controllers;

namespace FastCli.Sample.Tests
{
    public class InfoControllerTests
    {
        public class RunMethod
        {

            [Fact]
            public void Should_SayHiToTitle()
            {
                var view = new Mock<IInfoCommand>();
                view.SetupAllProperties();

                var controller = new InfoController();
                controller.RegisterView(view.Object);

                view.Object.Title = "John Doe";

                controller.Run();

                view.Object.Message.Should().Be("Hello John Doe");
            }
        }

    }
}
