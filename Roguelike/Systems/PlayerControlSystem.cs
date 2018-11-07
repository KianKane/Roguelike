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
                    {"players", new Type[] {typeof(PositionComponent), typeof(PlayerComponent)} },
                    {"tilemaps", new Type[] {typeof(TileMapComponent)} }
                };
            }
        }

        public override void Run(Dictionary<string, List<Entity>> entitySets)
        {
            // Clear readkey buffer
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }

            // Get direction
            Point direction = Point.zero;
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.UpArrow || keyInfo.Key == ConsoleKey.W)
                    direction = Point.up;
                else if (keyInfo.Key == ConsoleKey.DownArrow || keyInfo.Key == ConsoleKey.S)
                    direction = Point.down;
                else if (keyInfo.Key == ConsoleKey.RightArrow || keyInfo.Key == ConsoleKey.D)
                    direction = Point.right;
                else if (keyInfo.Key == ConsoleKey.LeftArrow || keyInfo.Key == ConsoleKey.A)
                    direction = Point.left;
            } while (direction == Point.zero);

            // Get player
            Entity player = entitySets["players"][0];
            Point playerPoint = player.GetComponent<PositionComponent>().point;

            // Get tile player will be standing on
            TileMapComponent tileMap = entitySets["tilemaps"][0].GetComponent<TileMapComponent>();
            Point newPoint = new Point(playerPoint.X + direction.X, playerPoint.Y + direction.Y);
            Tile tile;
            if (newPoint.X >= 0 && newPoint.X < tileMap.size.X && newPoint.Y >= 0 && newPoint.Y < tileMap.size.Y)
                tile = tileMap.map[newPoint.X, newPoint.Y];
            else
                tile = tileMap.outOfBounds;

            // Move player if tile is walkable
            if (tile.Walkable)
                player.SetComponent(new PositionComponent(newPoint));
        }
    }
}
