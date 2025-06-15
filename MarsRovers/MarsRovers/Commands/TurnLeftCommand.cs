using MarsRovers.Models;

namespace MarsRovers.Commands;

public class TurnLeftCommand : ICommand
{
    public void Execute(Rover rover, Plateau plateau) => rover.TurnLeft();
}
