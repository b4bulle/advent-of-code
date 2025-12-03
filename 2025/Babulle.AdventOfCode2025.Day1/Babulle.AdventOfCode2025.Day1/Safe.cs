namespace Babulle.AdventOfCode2025.Day1;

public class Safe(int startPosition = 0, int dialSize = 100)
{
    private int _position = (dialSize + startPosition) % dialSize;

    public int ApplyRotation(Rotation rotation)
    {
        var oldPosition = _position;
        var clicks = Math.Abs(rotation.Movement) / dialSize;
        var movementLeft = rotation.Movement - (int) rotation.Direction * clicks * dialSize;

        _position = (dialSize + oldPosition + movementLeft) % dialSize;

        if ((oldPosition - _position) * movementLeft > 0 && oldPosition != 0) ++clicks;
        if (_position == 0 && movementLeft < 0) ++clicks;
        
        return clicks;
    }
}
