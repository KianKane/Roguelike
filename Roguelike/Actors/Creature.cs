using Roguelike.Actions;
using Roguelike.DataTypes;

namespace Roguelike.Actors
{
    public class Creature : Actor
    {
        public Creature(Point position) : base(position, '!')
        {
        }

        public override IAction GetAction(Game game)
        {
            return new Move(this, Point.up);
        }
    }
}
