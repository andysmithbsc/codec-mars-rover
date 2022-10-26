
using MarsRover.Services;

Console.WriteLine("Welcome to the Codec Mars Rover");
Console.WriteLine("-------------------------------");
Console.WriteLine(" ");
Console.Write("Please enter the size of the plateau: ");
var size = Console.ReadLine();

Console.WriteLine(" ");
Console.Write("Please enter the route (L=Left, R=Right, F=Forward: ");
var route = Console.ReadLine();

var service = new RobotNavigator(size!);

var finalPosition = service.GetFinalPosition(route!);

Console.WriteLine(finalPosition);

Console.ReadLine();