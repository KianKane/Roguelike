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
                    {"cameras", new Type[] {typeof(CameraComponent)} }
                };
            }
        }

        public override void Run(Dictionary<string, List<Entity>> entitySets)
        {
            // Get camera data
            Entity camera = entitySets["cameras"][0];
            Point viewSize = camera.GetComponent<CameraComponent>().viewSize;

            // Set up console
            Console.SetWindowSize(viewSize.X + 1, viewSize.Y + 1);
            Console.SetBufferSize(viewSize.X + 1, viewSize.Y + 1);
            Console.CursorVisible = false;

            // Set up buffer
            char[,] buffer = new char[viewSize.X, viewSize.Y];
            for (int x = 0; x < viewSize.X; x++)
            {
                for (int y = 0; y < viewSize.Y; y++)
                {
                    buffer[x, y] = '.';
                }
            }

            // Draw entities to buffer
            foreach (Entity entity in entitySets["entities"])
            {
                Point point = entity.GetComponent<PositionComponent>().point;
                char symbol = entity.GetComponent<VisibleComponent>().symbol;
                if (point.X >= 0 && point.X < viewSize.X && point.Y >= 0 && point.Y < viewSize.Y)
                {
                    buffer[point.X, point.Y] = symbol;
                }
            }

            // Output buffer
            string output = "";
            for (int y = viewSize.Y - 1; y >= 0; y--)
            {
                for (int x = 0; x < viewSize.X; x++)
                {
                    output += buffer[x, y];
                }
                output += '\n';
            }
            Console.SetCursorPosition(0, 0);
            Console.Write(output);
        }
    }
}
