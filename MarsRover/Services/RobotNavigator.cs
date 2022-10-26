using MarsRover.Models;

namespace MarsRover.Services;

public class RobotNavigator
{
    private readonly Plateau _plateau;

    public RobotNavigator(string plateauSize)
    {
        _plateau = GeneratePlateau(plateauSize);
    }

    public Plateau GeneratePlateau(string plateauSize)
    {
        var values = plateauSize.Split('x');
        var maxWidth = Convert.ToInt32(values[0]);
        var maxLength = Convert.ToInt32(values[1]);

        return new Plateau(maxWidth, maxLength);
    }

    public string GetFinalPosition(string route, int startX = 1, int startY = 1)
    {
        var startPosition = new Coordinate(startX, startY);

        var robot = new Robot(startPosition, Direction.North);

        var moves = route.ToCharArray();
        
        foreach (var move in moves)
        {
            switch (move)
            {
                case 'L':
                    robot.Turn(Turning.Left);
                    break;
                case 'R':
                    robot.Turn(Turning.Right);
                    break;
                case 'F':
                    var newPosition = GetNewPosition(robot.CurrentPosition, robot.CurrentDirection);
                    if (_plateau.IsValidMove(newPosition))
                    {
                        robot.Move(newPosition);
                    }
                    break;
            }
        }

        var finalPosition = $"{robot.CurrentPosition.xPos},{robot.CurrentPosition.yPos},{robot.CurrentDirection.ToString()}"; 

        return finalPosition;
    }

    public Coordinate GetNewPosition(Coordinate currentPosition, Direction currentDirection)
    {
        switch (currentDirection)
        {
            case Direction.North:
                currentPosition.yPos = currentPosition.yPos + 1;
                break;
            case Direction.South:
                currentPosition.yPos = currentPosition.yPos - 1;
                break;
            case Direction.East:
                currentPosition.xPos = currentPosition.xPos + 1;
                break;
            case Direction.West:
                currentPosition.xPos = currentPosition.xPos - 1;
                break;
        }

        return new Coordinate(currentPosition.xPos, currentPosition.yPos);
    }
}

