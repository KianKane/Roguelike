namespace Roguelike
{
    public struct Point
    {
        public static readonly Point zero = new Point(0, 0);
        public static readonly Point up = new Point(0, 1);
        public static readonly Point down = new Point(0, -1);
        public static readonly Point left = new Point(-1, 0);
        public static readonly Point right = new Point(1, 0);

        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
