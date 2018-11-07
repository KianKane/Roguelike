using System;
using Roguelike.EntityComponentSystem;
using Roguelike.Components;
using System.Collections.Generic;

namespace Roguelike.Systems
{
    public class TileMapRenderSystem : EntityComponentSystem.System
    {
        public override Dictionary<string, Type[]> ComponentSets
        {
            get
            {
                return new Dictionary<string, Type[]>()
                {
                    {"tilemaps", new Type[] {typeof(TileMapComponent)} },
                    {"cameras", new Type[] {typeof(PositionComponent), typeof(CameraComponent)} }
                };
            }
        }

        public override void Run(Dictionary<string, List<Entity>> entitySets)
        {
            // Get camera data
            Entity camera = entitySets["cameras"][0];
            Point cameraPosition = camera.GetComponent<PositionComponent>().point;
            Point cameraSize = camera.GetComponent<CameraComponent>().viewSize;

            // Get tile map
            TileMapComponent tileMap = entitySets["tilemaps"][0].GetComponent<TileMapComponent>();

            // Set up console
            Console.SetWindowSize(cameraSize.X + 1, cameraSize.Y + 1);
            Console.SetBufferSize(cameraSize.X + 1, cameraSize.Y + 1);
            Console.CursorVisible = false;

            // Set up buffer
            char[,] buffer = new char[cameraSize.X, cameraSize.Y];
            for (int x = 0; x < cameraSize.X; x++)
            {
                for (int y = 0; y < cameraSize.Y; y++)
                {
                    Point point = ToTileSpace(new Point(x, y), cameraPosition, cameraSize);
                    if (point.X >= 0 && point.X < tileMap.size.X && point.Y >= 0 && point.Y < tileMap.size.Y)
                        buffer[x, y] = tileMap.map[point.X, point.Y].Symbol;
                    else
                        buffer[x, y] = tileMap.outOfBounds.Symbol;
                }
            }

            // Output buffer
            string output = "";
            for (int y = cameraSize.Y - 1; y >= 0; y--)
            {
                for (int x = 0; x < cameraSize.X; x++)
                {
                    output += buffer[x, y];
                }
                output += '\n';
            }
            Console.SetCursorPosition(0, 0);
            Console.Write(output);
        }

        private Point ToTileSpace(Point point, Point cameraPosition, Point cameraSize)
        {
            return new Point(point.X + (cameraPosition.X - cameraSize.X / 2), point.Y + (cameraPosition.Y - cameraSize.Y / 2));
        }
    }
}