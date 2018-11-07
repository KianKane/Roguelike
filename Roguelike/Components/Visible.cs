using Roguelike.EntityComponentSystem;

namespace Roguelike.Components
{
    public struct Visible : IComponent
    {
        public char symbol;

        public Visible(char symbol)
        {
            this.symbol = symbol;
        }
    }
}
