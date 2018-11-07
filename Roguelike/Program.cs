using Roguelike.Components;
using Roguelike.EntityComponentSystem;
using Roguelike.Systems;
using System.Collections.Generic;
using System.Threading;

namespace Roguelike
{
    public class Program
    {
        private const int VIEW_WIDTH = 100;
        private const int VIEW_HEIGHT = 60;

        static void Main(string[] args)
        {
            Renderer renderer = new Renderer(VIEW_WIDTH, VIEW_HEIGHT);

            ECS ecs = new ECS();
            ecs.AddSystem(new PlayerControlSystem());
            ecs.AddSystem(new EntityRenderSystem(renderer));

            ecs.AddEntity(new Entity(new List<IComponent> {
                new PlayerComponent(),
                new PositionComponent(new Point(10, 15)),
                new VisibleComponent('@')
            }));

            while (true)
            {
                renderer.Clear('.');
                ecs.Step();
                renderer.Render();
            }
        }
    }
}