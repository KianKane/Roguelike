using Roguelike.EntityComponentSystem;

namespace Roguelike.Components
{
    public struct PositionComponent : IComponent
    {
        public Point point;

        public PositionComponent(Point point)
        {
            this.point = point;
        }
    }
}
