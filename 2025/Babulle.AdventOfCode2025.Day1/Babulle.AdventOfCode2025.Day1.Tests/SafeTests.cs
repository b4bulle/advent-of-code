namespace Babulle.AdventOfCode2025.Day1.Tests;

public class SafeTests
{
    [Theory]
    [InlineData(0, EDirection.Right, 200, 2)]
    [InlineData(0, EDirection.Left, 200, 2)]
    [InlineData(0, EDirection.Right, 199, 1)]
    [InlineData(0, EDirection.Left, 199, 1)]
    [InlineData(1, EDirection.Left, 2, 1)]
    [InlineData(1, EDirection.Left, 80, 1)]
    [InlineData(1, EDirection.Left, 180, 2)]
    [InlineData(-1, EDirection.Right, 2, 1)]
    [InlineData(-1, EDirection.Right, 80, 1)]
    [InlineData(1, EDirection.Right, 80, 0)]
    [InlineData(80, EDirection.Left, 1, 0)]
    [InlineData(80, EDirection.Left, 80, 1)]
    [InlineData(80, EDirection.Left, 180, 2)]
    [InlineData(80, EDirection.Right, 120, 2)]
    [InlineData(80, EDirection.Right, 20, 1)]
    public void ApplyRotation_WhenGoingRight_ShouldReturnClicks(int startPosition, EDirection direction, int rotationTicks, int expectedClicks)
    {
        var safe = new Safe(startPosition);
        var rotation = new Rotation(direction, rotationTicks);
        var clicks = safe.ApplyRotation(rotation);
        
        Assert.Equal(expectedClicks, clicks);
    }
}