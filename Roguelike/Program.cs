using Roguelike.Components;
using Roguelike.EntityComponentSystem;
using Roguelike.Systems;
using System.Collections.Generic;

namespace Roguelike
{
    public class Program
    {
        static void Main(string[] args)
        {
            ECS ecs = new ECS();
            ecs.AddSystem(new TileMapRenderSystem());
            ecs.AddSystem(new EntityRenderSystem());
            ecs.AddSystem(new PlayerControlSystem());
            ecs.AddSystem(new CameraFollowSystem());

            // Player
            ecs.AddEntity(new Entity(new List<IComponent> {
                new PlayerComponent(),
                new PositionComponent(new Point(10, 15)),
                new VisibleComponent('@')
            }));

            // Camera
            ecs.AddEntity(new Entity(new List<IComponent> {
                new PositionComponent(new Point(10, 15)),
                new CameraComponent(new Point(100, 60))
            }));

            // Map
            ecs.AddEntity(new Entity(new List<IComponent> {
                new TileMapGenerator().Generate(new Point(200, 200))
            }));

            while (true)
            {
                ecs.Step();
            }
        }
    }
}