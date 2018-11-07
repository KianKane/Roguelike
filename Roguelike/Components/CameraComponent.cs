using Roguelike.EntityComponentSystem;

namespace Roguelike.Components
{
    public struct CameraComponent : IComponent
    {
        public Point viewSize;

        public CameraComponent(Point viewSize)
        {
            this.viewSize = viewSize;
        }
    }
}
