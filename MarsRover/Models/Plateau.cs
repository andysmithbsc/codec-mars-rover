namespace MarsRover.Models;

public class Plateau
{
    public int MaxWidth => _maxWidth;
    public int MaxLength => _maxLength;

    private readonly int _maxWidth;
    private readonly int _maxLength;

    public Plateau(int maxWidth, int maxLength)
    {
        _maxWidth = maxWidth;
        _maxLength = maxLength;
    }

    public bool IsValidMove(Coordinate coordinate)
    {
        return coordinate.xPos > 0 && 
               coordinate.xPos <= _maxWidth && 
               coordinate.yPos > 0 && 
               coordinate.yPos <= _maxLength;
    }
}
