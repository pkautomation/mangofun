using FluentAssertions;

namespace MangoTests.Tests;

[TestFixture]
public class TestsClass : TestsBase
{
    [Test]
    public void Test1()
    {
        Assert.Pass(Settings!.BaseUrl);
        Settings.Should().NotBeNull();
    }
}
