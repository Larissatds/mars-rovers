using MarsRovers.Exceptions;
using MarsRovers.Models;

namespace MarsRovers.Commands;

public class MoveCommand : ICommand
{
    public void Execute(Rover rover, Plateau plateau)
    {
        var currentPosition = rover.Position;
        var nextPosition = rover.Direction switch
        {
            Direction.N => new Position(currentPosition.X, currentPosition.Y + 1),
            Direction.S => new Position(currentPosition.X, currentPosition.Y - 1),
            Direction.E => new Position(currentPosition.X + 1, currentPosition.Y),
            Direction.W => new Position(currentPosition.X - 1, currentPosition.Y),
            _ => throw new InvalidOperationException("Direção inválida")
        };

        if (!plateau.IsWithinBounds(nextPosition))
            throw new InvalidMoveException("Movimento fora dos limites");

        if (plateau.IsOccupied(nextPosition))
            throw new InvalidMoveException("Posição já ocupada");

        plateau.Release(currentPosition);
        plateau.Occupy(nextPosition);

        rover.Position = nextPosition;
    }
}
