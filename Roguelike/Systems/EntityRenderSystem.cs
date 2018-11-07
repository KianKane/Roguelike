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

            // Draw entities to console
            foreach (Entity entity in entitySets["entities"])
            {
                Point point = ToCameraSpace(entity.GetComponent<PositionComponent>().point, cameraPosition, cameraSize);
                char symbol = entity.GetComponent<VisibleComponent>().symbol;
                if (point.X >= 0 && point.X < cameraSize.X && point.Y >= 0 && point.Y < cameraSize.Y)
                {
                    Console.SetCursorPosition(point.X, cameraSize.Y - 1 - point.Y);
                    Console.Write(symbol);
                }
            }
        }

        private Point ToCameraSpace(Point point, Point cameraPosition, Point cameraSize)
        {
            return new Point(point.X - (cameraPosition.X - cameraSize.X / 2), point.Y - (cameraPosition.Y - cameraSize.Y / 2));
        }
    }
}
