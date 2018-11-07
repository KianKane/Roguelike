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
            ecs.AddSystem(new PlayerControlSystem());
            ecs.AddSystem(new EntityRenderSystem());

            ecs.AddEntity(new Entity(new List<IComponent> {
                new PlayerComponent(),
                new PositionComponent(new Point(10, 15)),
                new VisibleComponent('@')
            }));

            ecs.AddEntity(new Entity(new List<IComponent> {
                new CameraComponent(new Point(100, 60))
            }));

            while (true)
            {
                ecs.Step();
            }
        }
    }
}