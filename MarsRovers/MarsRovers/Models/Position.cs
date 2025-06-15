namespace MarsRovers.Models;

public class Position
{
    public int X { get; set; }
    public int Y { get; set; }

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Position Clone() => new Position(X, Y);

    public override bool Equals(object? obj)
    {
        if (obj is not Position other) return false;
        return X == other.X && Y == other.Y;
    }

    public override int GetHashCode() => HashCode.Combine(X, Y);

    public override string ToString() => $"{X} {Y}";
}
