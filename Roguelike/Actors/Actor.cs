using Roguelike.Actions;
using Roguelike.DataTypes;

namespace Roguelike.Actors
{
    public abstract class Actor
    {
        public Point Position { get; internal set; }
        public char Symbol { get; internal set; }

        protected internal Actor(Point position, char symbol)
        {
            Position = position;
            Symbol = symbol;
        }

        internal abstract IAction GetAction(Game game);
    }
}
