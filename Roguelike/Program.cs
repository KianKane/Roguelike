using System;

namespace Roguelike
{
    public class Program
    {
        static void Main(string[] args)
        {
            Camera camera = new Camera(new Point(0, 0), new Point(100, 60));
            Map map = new Map(new Point(150, 90));
            Entity player = new Player { Position = Point.zero };
            while (true)
            {
                camera.ConfigureConsole();
                map.DrawMap(camera);
                IAction action = player.TakeTurn();
                action?.Execute();
                Console.SetCursorPosition(player.Position.X, camera.Size.Y - player.Position.Y);
                Console.Write('@');
                Console.ReadKey(true);
            }
        }
    }
}