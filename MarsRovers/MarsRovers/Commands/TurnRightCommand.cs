using MarsRovers.Models;

namespace MarsRovers.Commands;

public class TurnRightCommand : ICommand
{
    public void Execute(Rover rover, Plateau plateau) => rover.TurnRight();
}
