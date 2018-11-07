using System;
using Roguelike.EntityComponentSystem;
using Roguelike.Components;
using System.Collections.Generic;

namespace Roguelike.Systems
{
    public class PlayerControlSystem : EntityComponentSystem.System
    {
        public override Dictionary<string, Type[]> ComponentSets
        {
            get
            {
                return new Dictionary<string, Type[]>()
                {
                    {"players", new Type[] {typeof(PositionComponent), typeof(PlayerComponent)} }
                };
            }
        }

        public override void Run(Dictionary<string, List<Entity>> entitySets)
        {
            // Clear readkey buffer
            while (Console.KeyAvailable)
            {
                Console.ReadKey(false);
            }

            // Get direction
            Point direction = Point.zero;
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.UpArrow || keyInfo.Key == ConsoleKey.W)
                    direction = Point.up;
                else if (keyInfo.Key == ConsoleKey.DownArrow || keyInfo.Key == ConsoleKey.S)
                    direction = Point.down;
                else if (keyInfo.Key == ConsoleKey.RightArrow || keyInfo.Key == ConsoleKey.D)
                    direction = Point.right;
                else if (keyInfo.Key == ConsoleKey.LeftArrow || keyInfo.Key == ConsoleKey.A)
                    direction = Point.left;
            } while (direction == Point.zero);

            // Move player(s)
            foreach (Entity player in entitySets["players"])
            {
                PositionComponent position = player.GetComponent<PositionComponent>();
                player.SetComponent(new PositionComponent(new Point(position.point.X + direction.X, position.point.Y + direction.Y)));
            }
        }
    }
}
