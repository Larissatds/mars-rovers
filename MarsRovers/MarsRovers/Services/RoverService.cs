using MarsRovers.Commands;
using MarsRovers.Models;

namespace MarsRovers.Services;

public class RoverService
{
    private readonly Plateau _plateau;

    public RoverService(Plateau plateau)
    {
        _plateau = plateau;
    }

    public Rover CreateRover(Position position, Direction direction)
    {
        if (!_plateau.IsWithinBounds(position))
            throw new Exception("Posição inicial fora dos limites");

        if (_plateau.IsOccupied(position))
            throw new Exception("Posição já ocupada");

        var rover = new Rover(position, direction);
        _plateau.Occupy(position);
        return rover;
    }

    public void ExecuteCommands(Rover rover, string commandSequence)
    {
        foreach (char c in commandSequence)
        {
            ICommand command = c switch
            {
                'L' => new TurnLeftCommand(),
                'R' => new TurnRightCommand(),
                'M' => new MoveCommand(),
                _ => throw new Exception($"Comando inválido: {c}")
            };

            command.Execute(rover, _plateau);

            if (!_plateau.IsWithinBounds(rover.Position))
            {
                Console.WriteLine("Movimento resultou fora dos limites do planalto, comando ignorado.");
                break;
            }

            if (_plateau.IsOccupied(rover.Position))
            {
                Console.WriteLine("Movimento resultou em colisão com outra sonda, comando ignorado.");
                break;
            }
        }
    }
}
