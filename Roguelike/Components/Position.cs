using Roguelike.EntityComponentSystem;

namespace Roguelike.Components
{
    public struct Position : IComponent
    {
        public Point position;

        public Position(Point position)
        {
            this.position = position;
        }
    }
}
