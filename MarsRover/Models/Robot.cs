namespace MarsRover.Models;

public class Robot
{
    public Coordinate CurrentPosition => _currentPosition;
    public Direction CurrentDirection => _currentDirection;
    private Coordinate _currentPosition;
    private Direction _currentDirection;

    public Robot(Coordinate coordinate, Direction direction)
    {
        _currentPosition = coordinate;
        _currentDirection = direction;
    }

    public void Move(Coordinate coordinate)
    {
        _currentPosition = coordinate;
    }

    public void Turn(Turning turning)
    {
        switch (CurrentDirection)
        {
            case Direction.North:
                _currentDirection = turning == Turning.Left ? Direction.West : Direction.East;
                break;
            case Direction.South:
                _currentDirection = turning == Turning.Left ? Direction.East : Direction.West;
                break;
            case Direction.East:
                _currentDirection = turning == Turning.Left ? Direction.North : Direction.South;
                break;
            case Direction.West:
                _currentDirection = turning == Turning.Left ? Direction.South : Direction.North;
                break;

        }
    }
}
