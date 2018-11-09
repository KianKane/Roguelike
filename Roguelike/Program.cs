using Roguelike.Behaviours;
using Roguelike.EntityBehaviourAction;
using System;
using System.Collections.Generic;
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
            List<Entity> entities = new List<Entity>();
            entities.Add(player);
            while (true)
            {
                camera.ConfigureConsole();
                map.DrawMap(camera);
                Action turnAction = new Action("turn");
                turnAction.Parameters.Add("entity", player);
                entities.ForEach((e) => e.HandleAction(turnAction));
                Console.SetCursorPosition(player.GetBehaviour<Physical>().Position.X, camera.Size.Y - player.GetBehaviour<Physical>().Position.Y);
                Console.Write(player.GetBehaviour<Physical>().Symbol);
                Console.ReadKey(true);
            }
        }
    }
}