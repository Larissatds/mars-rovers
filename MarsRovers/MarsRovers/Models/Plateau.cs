namespace MarsRovers.Models;

public class Plateau
{
    public int MaxX { get; }
    public int MaxY { get; }
    public List<Position> OccupiedPositions { get; } = new();

    public Plateau(int maxX, int maxY)
    {
        MaxX = maxX;
        MaxY = maxY;
    }

    public bool IsWithinBounds(Position position) =>
        position.X >= 0 && position.X <= MaxX &&
        position.Y >= 0 && position.Y <= MaxY;

    public bool IsOccupied(Position position) =>
        OccupiedPositions.Any(p => p.Equals(position));

    public void Occupy(Position position) => OccupiedPositions.Add(position);

    public void Release(Position position) => OccupiedPositions.RemoveAll(p => p.Equals(position));
}
