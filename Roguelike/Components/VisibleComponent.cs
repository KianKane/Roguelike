using Roguelike.EntityComponentSystem;

namespace Roguelike.Components
{
    public struct VisibleComponent : IComponent
    {
        public char symbol;

        public VisibleComponent(char symbol)
        {
            this.symbol = symbol;
        }
    }
}
