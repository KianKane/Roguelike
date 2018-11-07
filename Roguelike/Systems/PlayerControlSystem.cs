using System;
using Roguelike.EntityComponentSystem;
using Roguelike.Components;
using System.Collections.Generic;

namespace Roguelike.Systems
{
    public class PlayerControlSystem : ECSSystem
    {
        public override Type[] ComponentSet
        {
            get
            {
                return new Type[] { typeof(Position), typeof(Player) };
            }
        }

        public override void Run(List<Entity> entities)
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
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                    direction = Point.up;
                else if (key.Key == ConsoleKey.DownArrow)
                    direction = Point.down;
                else if (key.Key == ConsoleKey.RightArrow)
                    direction = Point.right;
                else if (key.Key == ConsoleKey.LeftArrow)
                    direction = Point.left;
            } while (direction == Point.zero);

            // Move player(s)
            foreach (Entity player in entities)
            {
                Position position = player.GetComponent<Position>();
                player.SetComponent(new Position(new Point(position.position.X + direction.X, position.position.Y + direction.Y)));
            }
        }
    }
}
