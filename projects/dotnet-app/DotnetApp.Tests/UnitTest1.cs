using DotnetApp;

namespace DotnetApp.Tests;

public class ProgramTest
{
    [Fact]
    public void Greet_ReturnsExpectedMessage()
    {
        Assert.Equal("Hello from C#!", Program.Greet());
    }
}
