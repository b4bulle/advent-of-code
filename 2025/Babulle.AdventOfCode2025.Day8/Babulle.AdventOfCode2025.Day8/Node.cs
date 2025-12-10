namespace Babulle.AdventOfCode2025.Day8;

public class Node(int i, int j, float distance)
{
    public float Distance { get; set; } = distance;
    
    public int I { get; } = i;
    public int J { get; } = j;
}