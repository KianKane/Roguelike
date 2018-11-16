using Roguelike.DataTypes;
using System;

namespace RoguelikeView
{
    public class Camera
    {
        public Point Center { get; set; }
        public Point Size { get; }

        public Point BottomLeft { get { return Center - (Size / 2); } }

        public Camera(Point center, Point size)
        {
            Center = center;
            Size = size;
        }

        public void ConfigureConsole()
        {
            Console.SetWindowSize(Size.X + 1, Size.Y + 1);
            Console.SetBufferSize(Size.X + 1, Size.Y + 1);
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
        }

        public bool ScreenPointWithinBounds(Point point)
        {
            return point.X >= 0 && point.X < Size.X && point.Y >= 0 && point.Y < Size.Y;
        }

        public Point ToScreenSpace(Point worldSpace)
        {
            return new Point(worldSpace.X - (Center.X - (Size.X / 2)), -worldSpace.Y - (-Center.Y - (Size.Y / 2)));
        }
    }
}
