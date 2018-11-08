using System;

namespace Roguelike
{
    public class Camera
    {
        public Point Center { get; set; }
        public Point Size { get; }

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
        }

        public Point ToCameraSpace(Point worldSpace)
        {
            return new Point(worldSpace.X - (Center.X - Size.X / 2), worldSpace.Y - (Center.Y - Size.Y / 2));
        }

        public Point ToWorldSpace(Point cameraSpace)
        {
            return new Point(cameraSpace.X + (Center.X - Size.X / 2), cameraSpace.Y + (Center.Y - Size.Y / 2));
        }
    }
}
