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
            ecs.AddSystem(new EntityRenderSystem());
            ecs.AddSystem(new PlayerControlSystem());

            ecs.AddEntity(new Entity(new List<IComponent> {
                new PlayerComponent(),
                new PositionComponent(new Point(10, 15)),
                new VisibleComponent('@')
            }));

            ecs.AddEntity(new Entity(new List<IComponent> {
                new PositionComponent(new Point(10, 15)),
                new CameraComponent(new Point(100, 60))
            }));

            while (true)
            {
                ecs.Step();
            }
        }
    }
}