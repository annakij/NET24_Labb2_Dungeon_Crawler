
struct Position
{
    public int X;
    public int Y;

    public Position(Position position) : this(position.X, position.Y) { }

    public Position (int x, int y)
    {
        Y = y;
        X = x;
    }

    public int VerticalDistanceTo(Position position) => Math.Abs(position.X - this.X);
    public int HorisontalDistanceTo(Position position) => Math.Abs(position.Y - this.Y);

    public double DistanceTo(Position position)
    {
        int x = VerticalDistanceTo(position);
        int y = HorisontalDistanceTo(position);
        return Math.Sqrt(x * x + y * y);
    }
}

