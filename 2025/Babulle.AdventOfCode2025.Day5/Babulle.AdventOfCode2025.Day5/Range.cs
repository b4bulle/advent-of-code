namespace Babulle.AdventOfCode2025.Day5;

public class Range<T> where T : IComparable<T>
{
    public T Min { get; private set; }
    public T Max { get; private set; }
    
    public Range(T min, T max)
    {
        Min = min;
        Max = max;

        if (min.CompareTo(max) <= 0) return;
        Min = max;
        Max = min;
    }

    public bool Contains(T value)
    {
        return Min.CompareTo(value) <= 0 && Max.CompareTo(value) >= 0;
    }

    public bool OverlapsWith(Range<T> other)
    {
        return !(Max.CompareTo(other.Min) < 0 || Min.CompareTo(other.Max) > 0);
    }

    public Range<T> Fuse(Range<T> other)
    {
        if (Min.CompareTo(other.Min) > 0)
            Min = other.Min;
        if (Max.CompareTo(other.Max) < 0)
            Max = other.Max;
        return this;
    }
}