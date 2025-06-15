using MarsRovers.Exceptions;
using MarsRovers.Models;

public class Rover
{
    public Position Position { get; set; }
    public Direction Direction { get; private set; }

    public Rover(Position position, Direction direction)
    {
        Position = position;
        Direction = direction;
    }

    public void TurnLeft() => Direction = (Direction)(((int)Direction + 3) % 4);
    public void TurnRight() => Direction = (Direction)(((int)Direction + 1) % 4);

    public void MoveForward(Plateau plateau)
    {
        var nextPosition = GetNextPosition();

        if (!plateau.IsWithinBounds(nextPosition))
            throw new InvalidMoveException("Movimento fora dos limites");

        if (plateau.IsOccupied(nextPosition))
            throw new InvalidMoveException("Posição já ocupada");

        plateau.Release(Position);
        plateau.Occupy(nextPosition);

        SetPosition(nextPosition);
    }

    private Position GetNextPosition()
    {
        var currentPosition = Position;
        return Direction switch
        {
            Direction.N => new Position(currentPosition.X, currentPosition.Y + 1),
            Direction.S => new Position(currentPosition.X, currentPosition.Y - 1),
            Direction.E => new Position(currentPosition.X + 1, currentPosition.Y),
            Direction.W => new Position(currentPosition.X - 1, currentPosition.Y),
            _ => throw new InvalidOperationException("Direção inválida")
        };
    }

    private void SetPosition(Position position)
    {
        Position = position;
    }

    public void ExecuteCommands(string commands, Plateau plateau)
    {
        foreach (var command in commands)
        {
            switch (command)
            {
                case 'L':
                    TurnLeft();
                    break;
                case 'R':
                    TurnRight();
                    break;
                case 'M':
                    MoveForward(plateau);
                    break;
                default:
                    throw new ArgumentException($"Comando inválido: {command}");
            }
        }
    }

    public override string ToString() => $"{Position.X} {Position.Y} {Direction.ToString()[0]}";
}
