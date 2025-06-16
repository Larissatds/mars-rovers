using MarsRovers.Models;
using MarsRovers.Services;
using MarsRovers.Exceptions;
using Xunit;

namespace MarsRover.Tests;

public class RoverTests
{
    [Fact]
    public void Rover_Should_TurnLeftCorrectly()
    {
        var rover = new Rover(new Position(0, 0), Direction.N);
        rover.TurnLeft();
        Assert.Equal(Direction.W, rover.Direction);
    }

    [Fact]
    public void Rover_Should_TurnRightCorrectly()
    {
        var rover = new Rover(new Position(0, 0), Direction.N);
        rover.TurnRight();
        Assert.Equal(Direction.E, rover.Direction);
    }

    [Fact]
    public void Rover_Should_MoveForward()
    {
        var plateau = new Plateau(5, 5);
        var rover = new Rover(new Position(1, 2), Direction.N);
        rover.MoveForward(plateau);
        Assert.Equal(3, rover.Position.Y);
    }

    [Fact]
    public void Should_Throw_When_Moving_Out_OfBounds()
    {
        var plateau = new Plateau(5, 5);
        var service = new RoverService(plateau);
        var rover = service.CreateRover(new Position(5, 5), Direction.N);

        Assert.Throws<InvalidMoveException>(() => service.ExecuteCommands(rover, "M"));
    }

    [Fact]
    public void Should_Ignore_Movement_To_Occupied_Position()
    {
        var plateau = new Plateau(5, 5);
        var service = new RoverService(plateau);

        var rover1 = service.CreateRover(new Position(1, 2), Direction.N);
        service.ExecuteCommands(rover1, "M"); // rover1 vai para (1,3)

        var rover2 = service.CreateRover(new Position(1, 4), Direction.S);

        Assert.Throws<InvalidMoveException>(() => service.ExecuteCommands(rover2, "M"));
    }
}
