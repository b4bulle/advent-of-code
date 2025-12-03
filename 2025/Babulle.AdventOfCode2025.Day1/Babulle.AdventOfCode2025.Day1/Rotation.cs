namespace Babulle.AdventOfCode2025.Day1;

public class Rotation(EDirection direction, int ticks)
{
    public EDirection Direction { get; } = direction;
    public int Movement => (int)Direction * ticks;
}