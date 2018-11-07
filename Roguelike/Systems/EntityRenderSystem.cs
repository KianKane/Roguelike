using System;
using Roguelike.EntityComponentSystem;
using Roguelike.Components;
using System.Collections.Generic;

namespace Roguelike.Systems
{
    public class EntityRenderSystem : EntityComponentSystem.System
    {
        public override Dictionary<string, Type[]> ComponentSets
        {
            get
            {
                return new Dictionary<string, Type[]>()
                {
                    {"entities", new Type[] {typeof(PositionComponent), typeof(VisibleComponent)} },
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
                    buffer[x, y] = '.';
                }
            }

            // Draw entities to buffer
            foreach (Entity entity in entitySets["entities"])
            {
                Point point = ToCameraSpace(entity.GetComponent<PositionComponent>().point, cameraPosition, cameraSize);
                char symbol = entity.GetComponent<VisibleComponent>().symbol;
                if (point.X >= 0 && point.X < cameraSize.X && point.Y >= 0 && point.Y < cameraSize.Y)
                {
                    buffer[point.X, point.Y] = symbol;
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

        private Point ToCameraSpace(Point point, Point cameraPosition, Point cameraSize)
        {
            return new Point(point.X - (cameraPosition.X - cameraSize.X / 2), point.Y - (cameraPosition.Y - cameraSize.Y / 2));
        }
    }
}
