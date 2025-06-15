using MarsRovers.Models;
using MarsRovers.Services;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Informe o tamanho do planalto (exemplo: 5 5):");
        var plateauInput = Console.ReadLine();
        var plateauCoords = plateauInput.Split(' ');

        var plateau = new Plateau(int.Parse(plateauCoords[0]), int.Parse(plateauCoords[1]));

        var roverService = new RoverService(plateau);
        var rovers = new List<Rover>();

        while (true)
        {
            Console.WriteLine("Informe posição inicial da sonda (exemplo: 1 2 N), ou vazio para sair:");
            var posInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(posInput))
                break;

            var posParts = posInput.Split(' ');
            var x = int.Parse(posParts[0]);
            var y = int.Parse(posParts[1]);
            var dir = Enum.Parse<Direction>(posParts[2].ToUpper(), true);

            try
            {
                var rover = roverService.CreateRover(new Position(x, y), dir);

                Console.WriteLine("Informe comandos da sonda (exemplo: LMLMLMLMM):");
                var commands = Console.ReadLine();

                roverService.ExecuteCommands(rover, commands);

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
