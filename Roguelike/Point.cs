using System;

namespace Roguelike
{
    public struct Point : IEquatable<Point>
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

        public override int GetHashCode()
        {
            return X >> Y;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Point))
                return false;

            return Equals((Point)obj);
        }

        public bool Equals(Point other)
        {
            return X == other.X && Y == other.Y;
        }

        public static bool operator ==(Point left, Point right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Point left, Point right)
        {
            return !left.Equals(right);
        }
    }
}
