using Roguelike.EntityComponentSystem;

namespace Roguelike.Components
{
    public struct Position : IComponent
    {
        public Point point;

        public Position(Point point)
        {
            this.point = point;
        }
    }
}
