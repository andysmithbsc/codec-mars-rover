using FluentAssertions;
using MarsRover.Models;
using MarsRover.Services;
using TechTalk.SpecFlow;

namespace MarsRover.Tests.StepDefinitions;

[Binding]
public class NavigationStepDefinitions
{
    private const string DefaultPlateauSize = "10x8";
    private RobotNavigator? _robotNavigator;
    private Plateau? _plateau;
    private Coordinate? _knownCoordinate;
    private Coordinate? _expectedCoordinate;
    private Coordinate? _newCoordinate;
    private Direction ? _direction;
    
    [Given(@"I have a new instance of the Robot Navigator class")]
    public void GivenIHaveANewInstanceOfTheRobotNavigatorClass()
    {
        _robotNavigator = new RobotNavigator(DefaultPlateauSize);
    }

    [When(@"I call the GeneratePlateau method with a specific size")]
    public void WhenICallTheGeneratePlateauMethodWithASpecificSize()
    {
        _plateau = _robotNavigator!.GeneratePlateau(DefaultPlateauSize);
    }

    [Then(@"I have a Plateau with the expected size")]
    public void ThenIHaveAPlateauWithTheExpectedSize()
    {
        _plateau!.MaxWidth.Should().Be(10);

        _plateau!.MaxLength.Should().Be(8);
    }

    [Given(@"I have a known (.*) coordinate and (.*) coordinate")]
    public void GivenIHaveAKnownCoordinateAndCoordinate(int knownX, int knownY)
    {
        _knownCoordinate = new Coordinate(knownX, knownY);
    }

    [Given(@"I have an expected (.*) coordinate and (.*) coordinate")]
    public void GivenIHaveAnExpectedCoordinateAndCoordinate(int expectedX, int expectedY)
    {
        _expectedCoordinate = new Coordinate(expectedX, expectedY);
    }

    [When(@"I travel in a '(.*)' direction")]
    public void WhenITravelInADirection(string direction)
    {
        _newCoordinate = _knownCoordinate;

        switch (direction)
        {
            case "North":
                _newCoordinate.yPos = _newCoordinate.yPos + 1;
                break;
            case "South":
                _newCoordinate.yPos = _newCoordinate.yPos - 1;
                break;
            case "East":
                _newCoordinate.xPos = _newCoordinate.xPos + 1;
                break;
            case "West":
                _newCoordinate.xPos = _newCoordinate.xPos - 1;
                break;
        }
    }

    [Then(@"The new coordinate equals the expected coordinate")]
    public void ThenTheNewCoordinateEqualsTheExpectedCoordinate()
    {
        _newCoordinate.xPos.Should().Be(_expectedCoordinate.xPos);
        _newCoordinate.yPos.Should().Be(_expectedCoordinate.yPos);
    }
}

