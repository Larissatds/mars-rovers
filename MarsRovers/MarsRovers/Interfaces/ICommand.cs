using MarsRovers.Models;

namespace MarsRovers.Commands;

public interface ICommand
{
    void Execute(Rover rover, Plateau plateau);
}
