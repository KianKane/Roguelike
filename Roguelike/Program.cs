using Roguelike.Behaviours;
using Roguelike.EntityBehaviourAction;
using System;
using Action = Roguelike.EntityBehaviourAction.Action;

namespace Roguelike
{
    public class Program
    {
        static void Main(string[] args)
        {
            Camera camera = new Camera(new Point(0, 0), new Point(100, 60));
            Map map = new Map(new Point(150, 90));
            Entity player = new Entity(new Physical(map, new Point(10, 10), '@'), new Player(), new Drunk());
            EntityManager.Add(player);
            while (true)
            {
                camera.ConfigureConsole();
                map.DrawMap(camera);
                EntityManager.Fire(new Action("player_turn"));
                Console.SetCursorPosition(player.GetBehaviour<Physical>().Position.X, camera.Size.Y - player.GetBehaviour<Physical>().Position.Y);
                Console.Write(player.GetBehaviour<Physical>().Symbol);
                Console.ReadKey(true);
            }
        }
    }
}