using Xunit;

namespace test;

public class UnitTest1
{
    [Fact]
    public void Testsummer()
    {
        var d = DateStuff.Date.GetFirstOfMonthAsUTC(2022, 5);
        Assert.Equal(d.Month, 4);
        Assert.Equal(d.Day, 30);
        Assert.Equal(d.Hour, 22);
        Assert.Equal(d.Minute, 0);
    }

    [Fact]
    public void Testwinter()
    {
        var d = DateStuff.Date.GetFirstOfMonthAsUTC(2021, 2);
        Assert.Equal(d.Month, 1);
        Assert.Equal(d.Day, 31);
        Assert.Equal(d.Hour, 23);
        Assert.Equal(d.Minute, 0);
    }

}