namespace MarsRover.Models;

public class Coordinate
{
    public Coordinate(int xPos, int yPos)
    {
        this.xPos = xPos;
        this.yPos = yPos;
    }

    public int xPos { get; set; }

    public int yPos { get; set; }
}
