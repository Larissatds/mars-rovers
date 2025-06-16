using MarsRovers.Models;
using MarsRovers.Services;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Informe o tamanho do planalto (exemplo: 5 5):");
        var plateauInput = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(plateauInput))
        {
            Console.WriteLine("Entrada inválida. O programa será encerrado.");
            return;
        }

        var plateauCoords = plateauInput?.Split(' ');

        if (plateauCoords == null || plateauCoords.Length != 2 ||
            !int.TryParse(plateauCoords[0], out int plateauWidth) ||
            !int.TryParse(plateauCoords[1], out int plateauHeight))
        {
            Console.WriteLine("Coordenadas inválidas. O programa será encerrado.");
            return;
        }

        var plateau = new Plateau(plateauWidth, plateauHeight);

        var rovers = new List<Rover>();
        var roverService = new RoverService(plateau);

        while (true)
        {
            Console.WriteLine("Informe posição inicial da sonda (exemplo: 1 2 N), ou vazio para sair:");
            var posInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(posInput))
                break;

            var posParts = posInput.Split(' ');
            if (posParts.Length != 3 ||
                !int.TryParse(posParts[0], out int x) ||
                !int.TryParse(posParts[1], out int y) ||
                !Enum.TryParse<Direction>(posParts[2].ToUpper(), true, out var dir))
            {
                Console.WriteLine("Posição inicial inválida. Tente novamente.");
                continue;
            }

            try
            {
                var rover = roverService.CreateRover(new Position(x, y), dir);

                Console.WriteLine("Informe comandos da sonda (exemplo: LMLMLMLMM):");
                var commands = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(commands))
                {
                    Console.WriteLine("Comandos inválidos. Tente novamente.");
                    continue;
                }

                roverService.ExecuteCommands(rover, commands!);

                rovers.Add(rover);
                Console.WriteLine($"Posição final da sonda: {rover.Position.X} {rover.Position.Y} {rover.Direction.ToString()[0]}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao mover a sonda: {ex.Message}");
            }
        }

        Console.WriteLine("Fim das sondas.");
    }
}
