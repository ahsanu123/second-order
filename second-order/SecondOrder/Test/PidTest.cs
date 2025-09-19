using Xunit.Abstractions;
using SecondOrder;

namespace SecondOrder.Tests;

public class PidTest
{
    [Fact]
    public void TestOutput()
    {
        var result = MainPage.Simulate();
    }
}
